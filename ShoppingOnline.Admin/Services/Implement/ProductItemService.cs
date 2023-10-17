using ShoppingOnline.Admin.Constants;
using ShoppingOnline.Admin.Models.ProductItem;
using ShoppingOnline.Admin.Services.Interface;
using System.Net.Http.Json;

namespace ShoppingOnline.Admin.Services.Implement;

public class ProductItemService:IProductItemService
{
	private readonly IHttpClientFactory _clientFactory;

	public ProductItemService(IHttpClientFactory clientFactory)
	{
		_clientFactory = clientFactory;
	}

	public async Task<List<ProductItemVM>> GetProductItemsWithProductId(Guid productId)
	{
		var httpClient = _clientFactory.CreateClient(ApplicationConstant.ClientName);

		var response = await httpClient.GetFromJsonAsync<List<ProductItemVM>>($"api/ProductItems/get-all/{productId}");

		return response;
	}

	public async Task<ProductItemVM> GetProductItemById(Guid id)
	{
		var httpClient = _clientFactory.CreateClient(ApplicationConstant.ClientName);

		var response = await httpClient.GetFromJsonAsync<ProductItemVM>($"api/ProductItems/{id}");

		return response;
	}

	public async Task<bool> CreateProducItem(Guid productId, List<ProductItemCreateRequest> request)
	{
		var httpClient = _clientFactory.CreateClient(ApplicationConstant.ClientName);

		var response = await httpClient.PostAsJsonAsync($"api/ProductItems/creat-list/{productId}", request);

		return response.IsSuccessStatusCode;
	}

	public async Task<bool> UpdateProductItem(ProductItemUpdateRequest request)
	{
		var httpClient = _clientFactory.CreateClient(ApplicationConstant.ClientName);

		var response = await httpClient.PutAsJsonAsync("api/ProductItems", request);
		return response.IsSuccessStatusCode;
		if (!response.IsSuccessStatusCode)
		{
			var responseContent = await response.Content.ReadAsStringAsync();
			return false;
		}

		return true;
	}

	public async Task<List<ColorVM>> GetAllColor()
	{
		var httpClient = _clientFactory.CreateClient(ApplicationConstant.ClientName);

		var response = await httpClient.GetFromJsonAsync<List<ColorVM>>("api/Colors");

		return response;
	}

	public async Task<List<SizeVM>> GetAllSize()
	{
		var httpClient = _clientFactory.CreateClient(ApplicationConstant.ClientName);

		var response = await httpClient.GetFromJsonAsync<List<SizeVM>>("api/Sizes/Get-all");

		return response;	
	}
}