using Microsoft.AspNetCore.Components;
using MudBlazor;
using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.Order;
using ShoppingOnline.Admin.ViewModels.OrderItems;

namespace ShoppingOnline.Admin.Pages.Order;

public partial class Order
{
	private bool hover = true;
	private string searchString1 = "";
	private OrderGetDtos selectedItem1 = null;
	private HashSet<OrderGetDtos> selectedItems = new HashSet<OrderGetDtos>();
	[Inject] private IOrderServices _orderServices { get; set; }
	[Inject] private IOrderItemsServices _orderItemsServices { get; set; }
	[Inject] private IProductItemsChienServices _productItemsServices { get; set; }
	[Inject] private IDialogService DialogService { get; set; }

	private List<OrderGetDtos> _orderGetDtosEnumerabl = new List<OrderGetDtos>();
	private OrderStatusDtos _orderStatusDtos = new OrderStatusDtos();
	private IEnumerable<OrderItemsGet> _lstOrderItems = new List<OrderItemsGet>();

	[Inject] private ISnackbar Snackbar { get; set; }
	protected async override Task OnInitializedAsync()
	{
		await LoadData();
	}
	private bool FilterFunc1(OrderGetDtos element) => FilterFunc(element, searchString1);

	private bool FilterFunc(OrderGetDtos element, string searchString)
	{
		if (string.IsNullOrWhiteSpace(searchString))
			return true;
		if (element.CustomerName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
			return true;
		if (element.PhoneNumber.Contains(searchString, StringComparison.OrdinalIgnoreCase))
			return true;
		return false;
	}

	private async Task LoadData()
	{
		_orderGetDtosEnumerabl = await _orderServices.GetOrdersAsync();
		StateHasChanged();
	}

	private async void Confirmed(Guid id)
	{
		_orderStatusDtos.Id = id;

		foreach (var item in _orderGetDtosEnumerabl)
		{
			if (item.Id == _orderStatusDtos.Id)
			{
				if (item.OrderStatus == "PENDINGFORCOMFIRMATION")
				{
					_orderStatusDtos.OrderStatus = "CONFIRMED";
					var editStatus = await _orderServices.EditOrderStatus(_orderStatusDtos);
					if (editStatus)
					{
						Snackbar.Add("Xác nhận đơn hàng thành công", Severity.Info);
						await LoadData();
						return;
					}
					else
					{
						Snackbar.Add("Có lỗi xảy ra", Severity.Error);
					}
				}
				else if (item.OrderStatus == "CONFIRMED")
				{
					_orderStatusDtos.OrderStatus = "SUCCESS";
					var editStatus = await _orderServices.EditOrderStatus(_orderStatusDtos);
					if (editStatus)
					{
						Snackbar.Add("Hoàn thành đơn hàng", Severity.Success);
						await LoadData();
						return;
					}
					else
					{
						Snackbar.Add("Có lỗi xảy ra", Severity.Error);
					}
				}
				else if (item.OrderStatus == "CANCEL")
				{
					Snackbar.Add("Đơn hàng đã bị huỷ", Severity.Normal);
					return;
				}
				else
				{
					Snackbar.Add("Đơn hàng đã ở trạng thái hoàn thành", Severity.Normal);
					return;
				}
			}
		}
	}

	private async Task Cancel(Guid id)
	{
		_orderStatusDtos.Id = id;
		_lstOrderItems = (await _orderItemsServices.GetOrderItems()).Where(c => c.OrderId == id);
		foreach (var item in _orderGetDtosEnumerabl)
		{
			if (item.Id == _orderStatusDtos.Id)
			{
				if (item.OrderStatus == "PENDINGFORCOMFIRMATION" || item.OrderStatus == "CONFIRMED")
				{
					foreach (var orderItem in _lstOrderItems)
					{
						_orderStatusDtos.IdProductItems = orderItem.ProductItemId;
						_orderStatusDtos.Quantity = orderItem.Quantity;
						await _orderServices.EditOrderStatus(_orderStatusDtos);
					}
					_orderStatusDtos.OrderStatus = "CANCEL";
					var editStatus = await _orderServices.EditOrderStatus(_orderStatusDtos);
					if (editStatus)
					{
						await LoadData();
						Snackbar.Add("Đơn hàng đã huỷ", Severity.Error);
						return;
					}
					else
					{
						Snackbar.Add("Có lỗi xảy ra", Severity.Error);
					}
				}
				else if (item.OrderStatus == "CANCEL")
				{
					Snackbar.Add("Đơn hàng đã ở trạng thái huỷ", Severity.Normal);
					return;
				}
				else
				{
					Snackbar.Add("Đơn hàng đã ở trạng thái hoàn thành, không thể huỷ", Severity.Normal);
					return;
				}
			}
		}
	}
	private async Task OpenDialog(OrderGetDtos orderGetDtos)
	{
		var parameters = new DialogParameters<OrderDetailsDialog>();
		parameters.Add(c => c.OrderId, orderGetDtos.Id);
		var option = new DialogOptions() { MaxWidth = MaxWidth.ExtraLarge};
		var dialog = await DialogService.ShowAsync<OrderDetailsDialog>("Chi tiết đơn hàng", parameters, option);
		var result = await dialog.Result;

		if (!result.Canceled)
		{
			await LoadData();
		}

	}

}
