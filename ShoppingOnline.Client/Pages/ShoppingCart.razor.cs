using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using ShoppingOnline.Client.DataTransferObjects.CartDto;
using ShoppingOnline.Client.DataTransferObjects.ColorDto;
using ShoppingOnline.Client.DataTransferObjects.SizeDto;
using ShoppingOnline.Client.Services.ColorClient;
using ShoppingOnline.Client.Services.SizeClient;

namespace ShoppingOnline.Client.Pages;

public partial class ShoppingCart
{
	[Inject] private ILocalStorageService _localStorageService { get; set; }
	[Inject] private ISizeClientServices _sizeClientServices { get; set; }
	[Inject] private IColorClientServices _colorClientServices { get; set; }

	private List<CartDto> _cartDtos = new List<CartDto>();
	private IEnumerable<GetSize>? _getSizes;
	private IEnumerable<GetColor> _getColors;

	protected override async Task OnInitializedAsync()
	{
		_cartDtos = await _localStorageService.GetItemAsync<List<CartDto>>("abc");
		_getSizes = await _sizeClientServices.GetAllSizes();
		_getColors = await _colorClientServices.GetAllColors();
	}
}
