using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using ShoppingOnline.Client.DataTransferObjects.ProductDto;
using ShoppingOnline.Client.Services.ProductClient;

namespace ShoppingOnline.Client.Pages;

public partial class Index
{
	[Inject] private IProductClientServices _productClientServices { get; set; }

	private IEnumerable<GetProduct> _getProducts;



	protected override async Task OnInitializedAsync()
	{
		_getProducts = await _productClientServices.GetAllProduct();
	}
}
