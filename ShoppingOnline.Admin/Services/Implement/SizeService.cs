using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.Models;
using System.Net.Http.Json;

namespace ShoppingOnline.Admin.Services.Implement;

public class SizeService : ISizeService
{
	private HttpClient _httpClient;
	public SizeService(HttpClient httpClient)
	{
		_httpClient = httpClient;
		//_httpClient.BaseAddress = new Uri("https://localhost:5004");
	}
	public async Task<bool> CreateSize(SizesVM si)
	{
		var result = await _httpClient.PostAsJsonAsync("/api/Sizes/Post", si);
		return result.IsSuccessStatusCode;
	}

	public async Task<bool> DeleteSize(Guid id)
	{
		await _httpClient.DeleteAsync($"/api/Sizes/Delete-by-{id}");
		return true;
	}

	public async Task<List<SizesVM>> GetAllSizes()
	{
		var result = await _httpClient.GetFromJsonAsync<List<SizesVM>>("/api/Sizes/Get-all");
		return result;
	}

	public async Task<SizesVM> GetSize(Guid id)
	{
		var result = await _httpClient.GetFromJsonAsync<SizesVM>($"api/Sizes/Get-by-{id}");
		return result;
	}

	public async Task<bool> UpdateSize(SizesVM si)
	{
		await _httpClient.PutAsJsonAsync($"/api/Sizes/put-by-{si.Id}", si);
		return true;
	}
}
