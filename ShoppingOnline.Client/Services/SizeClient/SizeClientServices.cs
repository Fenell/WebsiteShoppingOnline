using ShoppingOnline.Client.DataTransferObjects.SizeDto;
using System.Net.Http.Json;

namespace ShoppingOnline.Client.Services.SizeClient;

public class SizeClientServices : ISizeClientServices
{
	private HttpClient _httpClient;

	public SizeClientServices(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}
	public async Task<IEnumerable<GetSize>> GetAllSizes()
	{
		var result = await _httpClient.GetFromJsonAsync<IEnumerable<GetSize>>("https://localhost:7259/api/Sizes/Get-all");
		return result;
	}
}
