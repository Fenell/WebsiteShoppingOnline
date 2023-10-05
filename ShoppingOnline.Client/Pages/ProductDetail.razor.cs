using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using ShoppingOnline.Client.DataTransferObjects.ColorDto;
using ShoppingOnline.Client.DataTransferObjects.ProductDto;
using ShoppingOnline.Client.DataTransferObjects.SizeDto;
using ShoppingOnline.Client.Services.ColorClient;
using ShoppingOnline.Client.Services.ProductClient;
using ShoppingOnline.Client.Services.SizeClient;
using Newtonsoft.Json;

namespace ShoppingOnline.Client.Pages;

public partial class ProductDetail
{
	[Inject] private IProductClientServices _productClientServices { get; set; }
	[Inject] private ISizeClientServices _sizeClientServices { get; set; }
	[Inject] private IColorClientServices _colorClientServices { get; set; }

	[Inject] private ILocalStorageService _localStorageService { get; set; }

	private string SessionValue = "";

	private GetProduct _getProducts { get; set; }
	private IEnumerable<GetSize>? _getSizes;
	private IEnumerable<GetColor> _getColors;
	[Parameter]
	public Guid ProductId { get; set; }

	protected override async Task OnInitializedAsync()
	{
		_getProducts = await _productClientServices.GetProductById(ProductId);
		_getSizes = await _sizeClientServices.GetAllSizes();
		_getColors = await _colorClientServices.GetAllColors();

		//SessionValue = await _localStorageService.GetItemAsync<string>("abc");
	}

	public async Task AddToCard()
	{
		//var product = JsonConvert.SerializeObject(_getProducts);

		//await _localStorageService.SetItemAsync("abc", product);
		//Console.WriteLine("đã  vào");
	}
}
