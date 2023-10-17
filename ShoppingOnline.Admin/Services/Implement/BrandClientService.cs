using ShoppingOnline.Admin.Constants;
using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.ViewModelClient;
using System.Net.Http.Json;

namespace ShoppingOnline.Admin.Services.Implement;

public class BrandClientService : IBrandClientService
{
	private readonly IHttpClientFactory _httpClientFactory;

	public BrandClientService(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	public async Task<bool> CreateBrandClient(BrandVM brand)
	{
		var httpClient =  _httpClientFactory.CreateClient(ApplicationConstant.ClientName);
		var response = await httpClient.PostAsJsonAsync<BrandVM>("api/Brands", brand);
		if (response.IsSuccessStatusCode)
		{
			return true;
		}
		return false;
	}

	public async Task<bool> DeleteBrandClient(Guid id)
	{
		var httpClient =  _httpClientFactory.CreateClient(ApplicationConstant.ClientName);

		await httpClient.DeleteAsync($"api/Brands/Delete-by-id-{id}");
		return true;
	}

	public Task<List<BrandVM>> GetAllBrandClient()
	{
		var httpClient =  _httpClientFactory.CreateClient(ApplicationConstant.ClientName);

		var response = httpClient.GetFromJsonAsync<List<BrandVM>>("api/Brands");
		return response;
	}

	public async Task<BrandVM> GetAllBrandClientById(Guid id)
	{
		var httpClient =  _httpClientFactory.CreateClient(ApplicationConstant.ClientName);

		var response = await httpClient.GetFromJsonAsync<BrandVM>($"api/Brands/get-by-id-{id}");
		return response;
	}


	public async Task<bool> UpdateBrandClient( BrandVM brandVM)
	{
		var httpClient =  _httpClientFactory.CreateClient(ApplicationConstant.ClientName);

		var response = await httpClient.PutAsJsonAsync($"api/Brands/put-by-id-{brandVM.Id}", brandVM);
		if (response.IsSuccessStatusCode)
		{
			return true;
		}
		return false;
	}
}
