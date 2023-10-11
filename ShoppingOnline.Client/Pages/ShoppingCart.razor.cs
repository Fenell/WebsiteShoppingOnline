using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Newtonsoft.Json;
using ShoppingOnline.Client.DataTransferObjects.CartDto;
using ShoppingOnline.Client.DataTransferObjects.ColorDto;
using ShoppingOnline.Client.DataTransferObjects.OrderDto;
using ShoppingOnline.Client.DataTransferObjects.ProductItemDto;
using ShoppingOnline.Client.DataTransferObjects.SizeDto;
using ShoppingOnline.Client.Services.ColorClient;
using ShoppingOnline.Client.Services.OrderClient;
using ShoppingOnline.Client.Services.ProductItemClient;
using ShoppingOnline.Client.Services.SizeClient;

namespace ShoppingOnline.Client.Pages;

public partial class ShoppingCart
{
	[Inject] private ILocalStorageService _localStorageService { get; set; }
	[Inject] private ISizeClientServices _sizeClientServices { get; set; }
	[Inject] private IColorClientServices _colorClientServices { get; set; }
	[Inject] private IProductItemClientServices _productItemClientServices { get; set; }
	[Inject] private IOrderClientServices _orderClientServices { get; set; }

	[Inject] private NavigationManager _navigationManager { get; set; }
	[Inject] private ISnackbar Snackbar { get; set; }

	private List<CartDto> _cartDtos = new List<CartDto>();
	private IEnumerable<GetSize>? _getSizes;
	private IEnumerable<GetColor> _getColors;
	private IEnumerable<ProductItemGet> _getProductItems;
	decimal totalAll;
	private OrderCreatedDto _orderCreated = new OrderCreatedDto();

	protected override async Task OnInitializedAsync()
	{
		_cartDtos = await _localStorageService.GetItemAsync<List<CartDto>>("abc") ?? new();
		_getSizes = await _sizeClientServices.GetAllSizes();
		_getColors = await _colorClientServices.GetAllColors();
		_getProductItems = await _productItemClientServices.GetProductsAsync();
		foreach (var x in _cartDtos)
		{
			totalAll += x.Total;
		}
	}

	private async Task RemoveProduct(Guid idProductItems)
	{
		_cartDtos = await _localStorageService.GetItemAsync<List<CartDto>>("abc");
		_cartDtos.Remove(_cartDtos.FirstOrDefault(c => c.Id == idProductItems));
		await _localStorageService.SetItemAsync("abc", _cartDtos);
	}

	private async Task ClearCart()
	{
		_cartDtos = await _localStorageService.GetItemAsync<List<CartDto>>("abc");
		_localStorageService.RemoveItemAsync("abc");
		_navigationManager.NavigateTo("/");
		Snackbar.Add("Giỏ hàng đã được xoá, mời bạn tiếp tục mua hàng !", Severity.Normal);
	}

	private async Task UpdateCard()
	{
		bool check = false;
		foreach (var item in _getProductItems)
		{
			if (_cartDtos.Any(c => c.IdProduct == item.ProductId && c.Quantity > item.Quantity))
			{
				check = true;
				Snackbar.Add("Sản phẩm trong cửa hàng không đủ !", Severity.Normal);
			}

		}

		if (check == false)
		{
			await _localStorageService.SetItemAsync("abc", _cartDtos);
			totalAll = 0;
			foreach (var x in _cartDtos)
			{
				totalAll += x.Total;
			}
			Snackbar.Add("Giỏ hàng đã được update !", Severity.Success);
		}
	}

	private async Task CheckOut()
	{
		_orderCreated.PromotionId = new Guid("6DFB12E5-04BC-4680-B953-4B53E8E56CB5");
		_orderCreated.Total = totalAll;
		_orderCreated.OrderItems = new List<OrderItemDto>();
		bool check = false;
		foreach (var cart in _cartDtos)
		{
			if (_getProductItems.Any(c => c.Id == cart.Id && c.Quantity <= 0))
			{
				check = true;
				Snackbar.Add("Sản phẩm hết hàng !", Severity.Error);
				return;
			}
			OrderItemDto orderItemDto = new OrderItemDto();
			orderItemDto.ProductItemId = cart.Id;
			orderItemDto.Quantity = cart.Quantity;
			orderItemDto.Price = cart.Price;
			_orderCreated.OrderItems.Add(orderItemDto);
		}
		if (check == false)
		{
			var result = await _orderClientServices.CreatedOrder(_orderCreated);
			if (result)
			{
				Snackbar.Add("Mua thành công !", Severity.Success);
				_navigationManager.NavigateTo("/");
				_cartDtos = await _localStorageService.GetItemAsync<List<CartDto>>("abc");
				_localStorageService.RemoveItemAsync("abc");
			}
			else
			{
				Snackbar.Add("Mua thất bại !", Severity.Error);
			}
		}
	}
}
