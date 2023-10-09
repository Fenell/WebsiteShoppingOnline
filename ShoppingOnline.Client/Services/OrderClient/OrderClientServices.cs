using ShoppingOnline.Client.DataTransferObjects.OrderDto;
using System.Net.Http.Json;

namespace ShoppingOnline.Client.Services.OrderClient;

public class OrderClientServices : IOrderClientServices
{
	private readonly HttpClient _httpClient;

	public OrderClientServices(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<bool> CreatedOrder(OrderCreatedDto createdDto)
	 {
		var result = await _httpClient.PostAsJsonAsync("https://localhost:7259/api/Orders", createdDto);
		return result.IsSuccessStatusCode;
	}
}
