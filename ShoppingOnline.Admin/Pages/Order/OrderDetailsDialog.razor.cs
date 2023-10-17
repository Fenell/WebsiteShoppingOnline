using Microsoft.AspNetCore.Components;
using MudBlazor;
using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.Color;
using ShoppingOnline.Admin.ViewModels.Details;
using ShoppingOnline.Admin.ViewModels.Order;
using ShoppingOnline.Admin.ViewModels.OrderItems;
using ShoppingOnline.Admin.ViewModels.Product;
using ShoppingOnline.Admin.ViewModels.ProductItems;
using ShoppingOnline.Admin.ViewModels.Size;

namespace ShoppingOnline.Admin.Pages.Order;

public partial class OrderDetailsDialog
{
	private bool hover = true;
	private string searchString1 = "";
	private OrderDetailsAll selectedItem1 = null;
	private bool FilterFunc1(OrderDetailsAll element) => FilterFunc(element, searchString1);

	private bool FilterFunc(OrderDetailsAll element, string searchString)
	{
		if (string.IsNullOrWhiteSpace(searchString))
			return true;
		if (element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
			return true;
		return false;
	}
	[CascadingParameter] MudDialogInstance MudDialog { get; set; }
	[Inject] private IOrderServices _orderServices { get; set; }
	[Inject] private IOrderItemsServices _OrderItemsServices { get; set; }
	[Inject] private IProductItemsChienServices _ProductItemsServices { get; set; }
	[Inject] private IProductChienServices _ProductServices { get; set; }
	[Inject] private IColorChienServices _ColorServices { get; set; }
	[Inject] private ISizeChienServices _SizeServices { get; set; }

	[Inject] private ISnackbar Snackbar { get; set; }

	OrderGetDtos OrderGetDtos = new OrderGetDtos();

	List<OrderItemsGet> OrderItemsGet = new List<OrderItemsGet>();

	ProductItemsGetDtos ProductItemsGetDtos = new ProductItemsGetDtos();

	ProductGetDtos Product = new ProductGetDtos();

	ColorDtos ColorDtos = new ColorDtos();
	List<ColorDtos> lstColorDtos = new List<ColorDtos>();

	private SizeDtos SizeDtos = new SizeDtos();
	List<SizeDtos> lstSizeDtos = new List<SizeDtos>();

	private OrderDetailsAll DetailsAll = new OrderDetailsAll();
	private List<OrderDetailsAll> _lstDetailsAll = new List<OrderDetailsAll>();

	private List<OrderDetailsAll> lstQuantityDau = new List<OrderDetailsAll>();

	void Submit() => MudDialog.Close(DialogResult.Ok(true));
	void Cancel() => MudDialog.Cancel();

	[Parameter]
	public Guid OrderId { get; set; }
	protected async override Task OnInitializedAsync()
	{
		OrderGetDtos = await _orderServices.GetOrderById(OrderId);
		OrderItemsGet = await _OrderItemsServices.GetOrderItems();
		foreach (var item in OrderItemsGet)
		{
			if (item.OrderId == OrderGetDtos.Id)
			{
				DetailsAll.Quantity = item.Quantity;
				DetailsAll.IdProdctItems = item.ProductItemId;
				ProductItemsGetDtos = await _ProductItemsServices.GetProductItemById(item.ProductItemId);
				Product = await _ProductServices.GetProductById(ProductItemsGetDtos.ProductId);
				ColorDtos = await _ColorServices.GetColorById(ProductItemsGetDtos.ColorId);
				SizeDtos = await _SizeServices.GetSizeById(ProductItemsGetDtos.SizeId);
				DetailsAll.Id = item.Id;
				DetailsAll.Name = Product.Name;
				DetailsAll.ColorName = ColorDtos.Name;
				DetailsAll.ColorId = ColorDtos.Id;
				DetailsAll.SizeName = SizeDtos.Name;
				DetailsAll.SizeId = SizeDtos.Id;
				_lstDetailsAll.Add(DetailsAll);
				DetailsAll = new OrderDetailsAll();
			}
		}
		LoadSizeColor();
		QuantityDau();
	}

	protected async void QuantityDau()
	{
		foreach (var item in _lstDetailsAll)
		{
			DetailsAll = new OrderDetailsAll();
			DetailsAll.Id = item.Id;
			DetailsAll.Quantity = item.Quantity;
			lstQuantityDau.Add(DetailsAll);
		}
	}

	protected async void LoadSizeColor()
	{
		foreach (var details in _lstDetailsAll)
		{

			ProductItemsGetDtos = await _ProductItemsServices.GetProductItemById(details.IdProdctItems);
			var resultColor = await _ColorServices.GetColorById(ProductItemsGetDtos.ColorId);
			ColorDtos.Id = resultColor.Id;
			ColorDtos.Name = resultColor.Name;
			lstColorDtos.Add(ColorDtos);
			ColorDtos = new ColorDtos();

			var resultSize = await _SizeServices.GetSizeById(details.SizeId);
			SizeDtos.Id = resultSize.Id;
			SizeDtos.Name = resultSize.Name;
			lstSizeDtos.Add(SizeDtos);
			SizeDtos = new SizeDtos();
		}
	}

	protected async Task EditOderItem(Guid id)
	{
		if (OrderGetDtos.OrderStatus == "PENDINGFORCOMFIRMATION" || OrderGetDtos.OrderStatus == "CONFIRMED")
		{
			var orderItem = await _OrderItemsServices.GetOrderItemEditQuantity(id);
			var productItem = await _ProductItemsServices.GetProductItemById(orderItem.ProductItemId);
			var quantityDau = lstQuantityDau.FirstOrDefault(c => c.Id == orderItem.Id);
			var total = quantityDau.Quantity + productItem.Quantity;
			foreach (var item in _lstDetailsAll)
			{
				if (orderItem.Id == item.Id)
				{
					if (item.Quantity > 0)
					{
						if (total >= item.Quantity && productItem.SizeId == item.SizeId &&
							productItem.ColorId == item.ColorId)
						{
							orderItem.Quantity = item.Quantity;
							orderItem.SizeId = item.SizeId;
							orderItem.ColorId = item.ColorId;
							await _OrderItemsServices.EditQuantity(orderItem);
							Snackbar.Add("Đã sửa", Severity.Success);
							MudDialog.Close(DialogResult.Ok(true));
						}
						else
						{
							Snackbar.Add($"Không đủ hàng, trong kho còn {productItem.Quantity} sản phẩm", Severity.Error);
						}
					}
					else
					{
						Snackbar.Add("Số lượng phải lớn hơn 0", Severity.Normal);
					}
				}
			}
		}
		else
		{
			Snackbar.Add("Đơn hàng phải ở trạng thái chưa xác nhận mới được sửa", Severity.Normal);
		}
	}
}
