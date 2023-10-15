using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.Models;
using System.Net.Http.Json;

namespace ShoppingOnline.Admin.Services.Implement;

public class ColorService : IColorService
{
	private HttpClient _httpClient;

	public ColorService(HttpClient httpClient)
	{
		_httpClient = httpClient;
		//_httpClient.BaseAddress = new Uri("https://localhost:5004");
	}

	public async Task<bool> CreateColor(ColorsVM Co)
	{
		var result = await _httpClient.PostAsJsonAsync("/api/Colors",Co);
		var content = await result.Content.ReadAsStringAsync();
		return result.IsSuccessStatusCode;
	}

	public async Task<bool> DeleteColor(Guid id)
	{
		await _httpClient.DeleteAsync($"/api/Colors/Delete-by-id-{id}");
		return true;
	}

	public async Task<List<ColorsVM>> GetAllColors()
	{
		var result = await _httpClient.GetFromJsonAsync<List<ColorsVM>>("/api/Colors");
		return result;
	}

	public async Task<ColorsVM> GetColor(Guid id)
	{
		var result = await _httpClient.GetFromJsonAsync<ColorsVM>($"/api/Colors/get-by-id-{id}");
		return result;
	}

	public async Task<bool> UpdateColor(ColorsVM Co)
	{
		await _httpClient.PutAsJsonAsync($"/api/Colors/put-by-id-{Co.Id}",Co) ;
		return true;
	}
}
