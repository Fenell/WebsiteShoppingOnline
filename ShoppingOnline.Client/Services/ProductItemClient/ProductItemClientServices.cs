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
		var result = await _httpClient.GetFromJsonAsync<IEnumerable<ProductItemGet>>("https://localhost:5004/api/ProductItems");
		return result;
	}

	public async Task<bool> UpdateProductItem(UpdateQuantity updateQuantity)
	{
		var result = await _httpClient.PutAsJsonAsync("https://localhost:5004/api/ProductItems", updateQuantity);
		if (!result.IsSuccessStatusCode)
		{
			var responseContent = await result.Content.ReadAsStringAsync();
		}
		return result.IsSuccessStatusCode;
	}
}

