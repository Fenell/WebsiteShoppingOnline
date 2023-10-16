using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.ViewModelClient;
using System.Net.Http.Json;

namespace ShoppingOnline.Admin.Services.Implement;

public class CategoryClientService : ICategoryClientService
{
	
	public HttpClient _httpClient;
	public CategoryClientService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}
	public async Task<bool> CreateCategory(CategoryVM ct)
	{
		var response = await _httpClient.PostAsJsonAsync<CategoryVM>("https://localhost:5004/api/Categories", ct);
		
		if (response.IsSuccessStatusCode)
		{
			return true;
		}
		return false;
	}

	public async Task<bool> DeleteCategory(Guid id)
	{
		var response = await _httpClient.DeleteAsync($"https://localhost:5004/api/Categories/Delete-by-id-{id}");
		if (response.IsSuccessStatusCode)
		{
			return true;
		}
		return false;

	}

	public Task<List<CategoryVM>> GetAll()
	{
		var response = _httpClient.GetFromJsonAsync<List<CategoryVM>>("https://localhost:5004/api/Categories");
		return response;
	}

	public async Task<CategoryVM> GetAllById(Guid id)
	{
		var response = await _httpClient.GetFromJsonAsync<CategoryVM>($"https://localhost:5004/api/Categories/get-by-id-{id}");
		return response;
	}

	public async Task<bool> UpdateCategory( CategoryVM categoryVM)
	{
		var response = await _httpClient.PutAsJsonAsync($"https://localhost:5004/api/Categories/put-by-id-{categoryVM.Id}", categoryVM);
		if (response.IsSuccessStatusCode)
		{
			return true;
		}
		return false;
	}


}
