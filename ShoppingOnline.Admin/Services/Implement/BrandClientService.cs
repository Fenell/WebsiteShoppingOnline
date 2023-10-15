using ShoppingOnline.Admin.Pages.BrandTask;
using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.ViewModelClient;
using System.Net.Http.Json;

namespace ShoppingOnline.Admin.Services.Implement;

public class BrandClientService : IBrandClientService
{
	private readonly IBrandClientService _brandClientService;

	public HttpClient _httpClient;
	public BrandClientService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<bool> CreateBrandClient(BrandVM brand)
	{
		var response = await _httpClient.PostAsJsonAsync<BrandVM>("https://localhost:5004/api/Brands", brand);
		if (response.IsSuccessStatusCode)
		{
			return true;
		}
		return false;
	}

	public async Task<bool> DeleteBrandClient(Guid id)
	{
		await _httpClient.DeleteAsync($"https://localhost:5004/api/Brands/Delete-by-id-{id}");
		return true;
	}

	public Task<List<BrandVM>> GetAllBrandClient()
	{
		var response = _httpClient.GetFromJsonAsync<List<BrandVM>>("https://localhost:5004/api/Brands");
		return response;
	}

	public async Task<BrandVM> GetAllBrandClientById(Guid id)
	{
		var response = await _httpClient.GetFromJsonAsync<BrandVM>($"https://localhost:5004/api/Brands/get-by-id-{id}");
		return response;
	}


	public async Task<bool> UpdateBrandClient( BrandVM brandVM)
	{
		var response = await _httpClient.PutAsJsonAsync($"https://localhost:5004/api/Brands/put-by-id-{brandVM.Id}", brandVM);
		if (response.IsSuccessStatusCode)
		{
			return true;
		}
		return false;
	}
}
