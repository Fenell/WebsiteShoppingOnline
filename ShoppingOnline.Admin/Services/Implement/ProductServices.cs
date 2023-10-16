using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.Product;
using System.Net.Http.Json;

namespace ShoppingOnline.Admin.Services.Implement;

public class ProductServices : IProductServices
{
	private readonly HttpClient _httpClient;

	public ProductServices(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}
	public async Task<ProductGetDtos> GetProductById(Guid id)
	{
		var result = await _httpClient.GetFromJsonAsync<ProductGetDtos>($"https://localhost:5004/api/Products/{id}");
		return result;
	}
}
