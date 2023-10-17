using ShoppingOnline.Client.DataTransferObjects.ColorDto;
using System.Net.Http.Json;

namespace ShoppingOnline.Client.Services.ColorClient;

public class ColorClientServices : IColorClientServices
{
	private HttpClient _httpClient;

	public ColorClientServices(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}
	public async Task<IEnumerable<GetColor>> GetAllColors()
	{
		var result = await _httpClient.GetFromJsonAsync<IEnumerable<GetColor>>("https://localhost:5004/api/Colors");
		return result;
	}
}
