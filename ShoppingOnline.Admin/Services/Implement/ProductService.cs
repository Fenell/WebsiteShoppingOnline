using ShoppingOnline.Admin.Constants;
using ShoppingOnline.Admin.Models.Product;
using ShoppingOnline.Admin.Services.Interface;
using System.Net.Http.Json;

namespace ShoppingOnline.Admin.Services.Implement;

public class ProductService : IProductService
{
	private readonly IHttpClientFactory _clientFactory;
	private readonly HttpClient _client;

	public ProductService(IHttpClientFactory clientFactory, HttpClient client)
	{
		_clientFactory = clientFactory;
		_client = client;
	}

	public async Task<List<ProductVM>> GetAllProduct()
	{
		var httpClient = _clientFactory.CreateClient(ApplicationConstant.ClientName);

		var response = await httpClient.GetFromJsonAsync<List<ProductVM>>("/api/Products");

		return response;
	}

	public async Task<ProductVM> GetProduct(Guid id)
	{
		var httpClient = _clientFactory.CreateClient(ApplicationConstant.ClientName);

		var response = await httpClient.GetFromJsonAsync<ProductVM>($"api/Products/{id}");
		return response;
	}

	public async Task<bool> CreateProduct(ProductCreateRequest request)
	{
		var httpClient = _clientFactory.CreateClient(ApplicationConstant.ClientName);
		var response = await httpClient.PostAsJsonAsync("api/Products", request);

		if (!response.IsSuccessStatusCode)
			return false;
		return true;
	}

	public async Task<bool> UpdateProduct(ProductUpdateRequest request)
	{
		var httpClient = _clientFactory.CreateClient(ApplicationConstant.ClientName);
		var response = await httpClient.PutAsJsonAsync("api/Products", request);

		if (response.IsSuccessStatusCode)
			return true;

		return false;
	}

	public async Task<bool> ChangeStatus(Guid id)
	{
		var httpClient = _clientFactory.CreateClient(ApplicationConstant.ClientName);

		var response = await httpClient.PatchAsync($"/api/Products/{id}", null);
		if (response.IsSuccessStatusCode)
			return true;

		return false;
	}

	public async Task<List<CategoryVM>> GetAllCategoy()
	{
		var httpClient = _clientFactory.CreateClient(ApplicationConstant.ClientName);

		var response = await httpClient.GetFromJsonAsync<List<CategoryVM>>("api/Categories");

		return response;
	}

	public async Task<List<BrandVM>> GetAllBrand()
	{
		var httpClient = _clientFactory.CreateClient(ApplicationConstant.ClientName);

		var response = await httpClient.GetFromJsonAsync<List<BrandVM>>("api/Brands");

		return response;
	}
}