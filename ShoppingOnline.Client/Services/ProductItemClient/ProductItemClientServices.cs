using ShoppingOnline.Client.DataTransferObjects.ProductItemDto;
using System.Net.Http.Json;

namespace ShoppingOnline.Client.Services.ProductItemClient;

public class ProductItemClientServices : IProductItemClientServices
{
	private readonly HttpClient _httpClient;

	public ProductItemClientServices(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}
	public async Task<IEnumerable<ProductItemGet>> GetProductsAsync()
	{
		var result = await _httpClient.GetFromJsonAsync<IEnumerable<ProductItemGet>>("https://localhost:7259/api/ProductItems");
		return result;
	}
}
