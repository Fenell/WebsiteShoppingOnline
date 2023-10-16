﻿using Microsoft.AspNetCore.Components;
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

	[Inject] private IOrderServices _orderServices { get; set; }
	[Inject] private IOrderItemsServices _OrderItemsServices { get; set; }
	[Inject] private IProductItemsServices _ProductItemsServices { get; set; }
	[Inject] private IProductServices _ProductServices { get; set; }
	[Inject] private IColorServices _ColorServices { get; set; }
	[Inject] private ISizeServices _SizeServices { get; set; }

	[Inject] private ISnackbar Snackbar { get; set; }

	OrderGetDtos OrderGetDtos = new OrderGetDtos();

	OrderItemsGet orderItem = new OrderItemsGet();

	List<OrderItemsGet> OrderItemsGet = new List<OrderItemsGet>();

	ProductItemsGetDtos ProductItemsGetDtos = new ProductItemsGetDtos();
	private List<ProductItemsGetDtos> lstProductItemsGetDtos = new List<ProductItemsGetDtos>();

	ProductGetDtos Product = new ProductGetDtos();

	ColorDtos ColorDtos = new ColorDtos();
	List<ColorDtos> lstColorDtos = new List<ColorDtos>();

	private SizeDtos SizeDtos = new SizeDtos();
	List<SizeDtos> lstSizeDtos = new List<SizeDtos>();

	private OrderDetailsAll DetailsAll = new OrderDetailsAll();
	private List<OrderDetailsAll> _lstDetailsAll = new List<OrderDetailsAll>();

	OrderItemEditQuantity editQuantity = new OrderItemEditQuantity();

	[CascadingParameter] MudDialogInstance MudDialog { get; set; }


	void Submit() => MudDialog.Close(DialogResult.Ok(true));
	void Cancel() => MudDialog.Cancel();

	[Parameter]
	public Guid OrderId { get; set; }
	protected async override Task OnInitializedAsync()
	{
		OrderGetDtos = await _orderServices.GetOrderById(OrderId);
		OrderItemsGet = await _OrderItemsServices.GetOrderItems();
		lstProductItemsGetDtos = await _ProductItemsServices.GetProductItems();
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
			foreach (var item in _lstDetailsAll)
			{
				if (orderItem.Id == item.Id)
				{
					if (item.Quantity > 0)
					{
						if (productItem.Quantity >= item.Quantity && productItem.SizeId == item.SizeId &&
							productItem.ColorId == item.ColorId)
						{
							orderItem.Quantity = item.Quantity;
							orderItem.SizeId = item.SizeId;
							orderItem.ColorId = item.ColorId;
							await _OrderItemsServices.EditQuantity(orderItem);
							Snackbar.Add("Đã sửa", Severity.Success);
						}
						else
						{
							Snackbar.Add("Không đủ hàng", Severity.Error);
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
