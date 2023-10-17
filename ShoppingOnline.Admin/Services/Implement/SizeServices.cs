using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.Size;
using System.Net.Http.Json;

namespace ShoppingOnline.Admin.Services.Implement;

public class SizeServices : ISizeChienServices
{
	private readonly HttpClient _httpClient;

	public SizeServices(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}
	public async Task<SizeDtos> GetSizeById(Guid id)
	{
		var result = await _httpClient.GetFromJsonAsync<SizeDtos>($"https://localhost:5004/api/Sizes/Get-by-{id}");
		return result;
	}

	public async Task<List<SizeDtos>> GetAllSize()
	{
		var result = await _httpClient.GetFromJsonAsync<List<SizeDtos>>("https://localhost:5004/api/Sizes/Get-all");
		return result;
	}
}
