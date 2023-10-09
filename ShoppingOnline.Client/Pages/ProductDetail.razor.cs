using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Newtonsoft.Json;
using ShoppingOnline.Client.DataTransferObjects.CartDto;
using ShoppingOnline.Client.DataTransferObjects.ColorDto;
using ShoppingOnline.Client.DataTransferObjects.ProductDto;
using ShoppingOnline.Client.DataTransferObjects.ProductItemDto;
using ShoppingOnline.Client.DataTransferObjects.SizeDto;
using ShoppingOnline.Client.Services.ColorClient;
using ShoppingOnline.Client.Services.ProductClient;
using ShoppingOnline.Client.Services.ProductItemClient;
using ShoppingOnline.Client.Services.SizeClient;

namespace ShoppingOnline.Client.Pages;

public partial class ProductDetail
{
	[Inject] private IProductClientServices _productClientServices { get; set; }
	[Inject] private ISizeClientServices _sizeClientServices { get; set; }
	[Inject] private IColorClientServices _colorClientServices { get; set; }
	[Inject] private IProductItemClientServices _productItemClientServices { get; set; }

	[Inject] private ILocalStorageService _localStorageService { get; set; }
	[Inject] private NavigationManager _navigationManager { get; set; }
	[Inject] private ISnackbar Snackbar { get; set; }


	private GetProduct _getProducts { get; set; }
	private IEnumerable<GetSize>? _getSizes;
	private IEnumerable<GetColor> _getColors;
	private IEnumerable<ProductItemGet> _getProductItems;
	[Parameter]
	public Guid ProductId { get; set; }

	private CartDto _cartDto = new CartDto();
	private List<CartDto> _lstcartDto;

	protected override async Task OnInitializedAsync()
	{
		_getProducts = await _productClientServices.GetProductById(ProductId);
		_getSizes = await _sizeClientServices.GetAllSizes();
		_getColors = await _colorClientServices.GetAllColors();
		_getProductItems = await _productItemClientServices.GetProductsAsync();

	}

	public async Task AddToCard()
	{
		_lstcartDto = await _localStorageService.GetItemAsync<List<CartDto>>("abc");

		if (_cartDto.Size == null || _cartDto.Color == null || _cartDto.Quantity == 0)
		{
			Snackbar.Add($"Bạn chưa chọn size, màu hoặc số lượng !", Severity.Warning);
			return;
		}
		_cartDto.IdProduct = _getProducts.Id;
		_cartDto.Price = _getProducts.Price;
		bool check1 = false;
		foreach (var x in _getProductItems)
		{
			_cartDto.Id = x.Id;

			if (x.ProductId == _cartDto.IdProduct && x.ColorId.ToString() == _cartDto.Color && x.SizeId.ToString() == _cartDto.Size && x.Quantity > 0)
			{

				check1 = true;
				if (_lstcartDto == null)
				{
					if (_cartDto.Quantity > x.Quantity)
					{
						Snackbar.Add($"Trong kho chỉ còn {x.Quantity} sản phẩm !", Severity.Normal);
						return;
					}
					_lstcartDto = new List<CartDto>();
					_cartDto.Name = _getProducts.Name;
					_cartDto.Price = _getProducts.Price;
					_lstcartDto.Add(_cartDto);
				}
				else
				{
					bool check = false;
					_cartDto.Name = _getProducts.Name;
					_cartDto.Price = _getProducts.Price;
					foreach (var item in _lstcartDto)
					{
						if (item.Name == _cartDto.Name && item.Size == _cartDto.Size && item.Color == _cartDto.Color)
						{
							check = true;
							var totalQuantity = item.Quantity + _cartDto.Quantity;
							if (totalQuantity > x.Quantity)
							{
								Snackbar.Add($"Trong kho chỉ còn {x.Quantity} sản phẩm và trong giỏ hàng bạn đã có {item.Quantity} sản phẩm !", Severity.Normal);
								return;
							}
							item.Quantity += _cartDto.Quantity;
						}
					}

					if (check == false)
					{
						_lstcartDto.Add(_cartDto);
					}
				}

				await _localStorageService.SetItemAsync("abc", _lstcartDto);
				Snackbar.Add("Thêm vào giỏ hàng thành công !", Severity.Success);
				_navigationManager.NavigateTo("shopping-cart");
			}

		}
		if (check1 == false)
		{
			Snackbar.Add("Sản phẩm hết hàng !", Severity.Error);
		}

	}
}
