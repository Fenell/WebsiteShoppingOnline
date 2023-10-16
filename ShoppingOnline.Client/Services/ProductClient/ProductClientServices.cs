using ShoppingOnline.Client.DataTransferObjects.ProductDto;
using System.Net.Http.Json;

namespace ShoppingOnline.Client.Services.ProductClient;

public class ProductClientServices : IProductClientServices
{
	private HttpClient _httpClient;

	public ProductClientServices(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}
	public async Task<IEnumerable<GetProduct>> GetAllProduct()
	{
		var result = await _httpClient.GetFromJsonAsync<IEnumerable<GetProduct>>("https://localhost:5004/api/Products");
		return result;
	}

	public async Task<GetProduct> GetProductById(Guid id)
	{
		var result = await _httpClient.GetFromJsonAsync<GetProduct>($"https://localhost:5004/api/Products/{id}");
		return result;
	}
}
