using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.Color;
using System.Net.Http.Json;

namespace ShoppingOnline.Admin.Services.Implement;

public class ColorServices : IColorServices
{
	private readonly HttpClient _httpClient;

	public ColorServices(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}
	public async Task<List<ColorDtos>> GetAllColor()
	{
		var result = await _httpClient.GetFromJsonAsync<List<ColorDtos>>("https://localhost:5004/api/Colors");
		return result;
	}

	public async Task<ColorDtos> GetColorById(Guid id)
	{
		var result = await _httpClient.GetFromJsonAsync<ColorDtos>($"https://localhost:5004/api/Colors/get-by-id-{id}");
		return result;
	}
}
