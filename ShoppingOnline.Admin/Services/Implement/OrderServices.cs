using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.Order;
using System.Net.Http.Json;

namespace ShoppingOnline.Admin.Services.Implement;

public class OrderServices : IOrderServices
{
	private readonly HttpClient _httpClient;

	public OrderServices(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}
	public async Task<List<OrderGetDtos>> GetOrdersAsync()
	{
		var result = await _httpClient.GetFromJsonAsync<List<OrderGetDtos>>("https://localhost:5004/api/Orders");
		return result;
	}

	public async Task<bool> EditOrderStatus(OrderStatusDtos orderStatus)
	{
		var result = await _httpClient.PutAsJsonAsync($"https://localhost:5004/api/Orders/update-status", orderStatus);

		if (!result.IsSuccessStatusCode)
		{
			var responseContent = await result.Content.ReadAsStringAsync();
		}
		return result.IsSuccessStatusCode;
	}

	public async Task<OrderGetDtos> GetOrderById(Guid Id)
	{
		var result = await _httpClient.GetFromJsonAsync<OrderGetDtos>($"https://localhost:5004/api/Orders/order-by-id?id={Id}");
		return result;
	}
}
