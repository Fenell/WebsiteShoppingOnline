using ShoppingOnline.Admin.Constants;
using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.ViewModelClient;
using System.Net.Http.Json;

namespace ShoppingOnline.Admin.Services.Implement;

public class CategoryClientService : ICategoryClientService
{
	private readonly IHttpClientFactory _httpClientFactory;
	public CategoryClientService(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}
	public async Task<bool> CreateCategory(CategoryVM ct)
	{
		var httpClient =  _httpClientFactory.CreateClient(ApplicationConstant.ClientName);
		var response = await httpClient.PostAsJsonAsync<CategoryVM>("api/Categories", ct);
		
		if (response.IsSuccessStatusCode)
		{
			return true;
		}
		return false;
	}

	public async Task<bool> DeleteCategory(Guid id)
	{
		var httpClient =  _httpClientFactory.CreateClient(ApplicationConstant.ClientName);
		var response = await httpClient.DeleteAsync($"api/Categories/Delete-by-id-{id}");
		if (response.IsSuccessStatusCode)
		{
			return true;
		}
		return false;

	}

	public Task<List<CategoryVM>> GetAll()
	{
		var httpClient =  _httpClientFactory.CreateClient(ApplicationConstant.ClientName);

		var response = httpClient.GetFromJsonAsync<List<CategoryVM>>("api/Categories");
		return response;
	}

	public async Task<CategoryVM> GetAllById(Guid id)
	{
		var httpClient =  _httpClientFactory.CreateClient(ApplicationConstant.ClientName);

		var response = await httpClient.GetFromJsonAsync<CategoryVM>($"api/Categories/get-by-id-{id}");
		return response;
	}

	public async Task<bool> UpdateCategory( CategoryVM categoryVM)
	{

		var httpClient =  _httpClientFactory.CreateClient(ApplicationConstant.ClientName);

		var response = await httpClient.PutAsJsonAsync($"api/Categories/put-by-id-{categoryVM.Id}", categoryVM);
		var responseContent = await response.Content.ReadAsStringAsync();
		if (response.IsSuccessStatusCode)
		{
			return true;
		}
		return false;
	}


}
