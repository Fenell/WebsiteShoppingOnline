using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.ProductItems;
using System.Net.Http.Json;

namespace ShoppingOnline.Admin.Services.Implement;

public class ProductItemsServices : IProductItemsChienServices
{
	private readonly HttpClient _httpClient;

	public ProductItemsServices(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}
	public async Task<ProductItemsGetDtos> GetProductItemById(Guid id)
	{
		var result = await _httpClient.GetFromJsonAsync<ProductItemsGetDtos>($"https://localhost:5004/api/ProductItems/product-item-id?id={id}");
		return result;
	}

	public async Task<List<ProductItemsGetDtos>> GetProductItems()
	{
		var result = await _httpClient.GetFromJsonAsync<List<ProductItemsGetDtos>>("https://localhost:5004/api/ProductItems");
		return result;
	}
}
