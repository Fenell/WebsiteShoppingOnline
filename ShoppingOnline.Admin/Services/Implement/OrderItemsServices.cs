using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.OrderItems;
using System.Net.Http.Json;

namespace ShoppingOnline.Admin.Services.Implement;

public class OrderItemsServices : IOrderItemsServices
{
	private readonly HttpClient _httpClient;

	public OrderItemsServices(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}
	public async Task<List<OrderItemsGet>> GetOrderItems()
	{
		var result = await _httpClient.GetFromJsonAsync<List<OrderItemsGet>>("https://localhost:5004/api/OrderItems");
		return result;
	}

	public async Task<OrderItemEditQuantity> GetOrderItemEditQuantity(Guid id)
	{
		var result = await _httpClient.GetFromJsonAsync<OrderItemEditQuantity>($"https://localhost:5004/api/OrderItems/order-item-by-id?id={id}");
		return result;
	}

	public async Task<bool> EditQuantity(OrderItemEditQuantity editQuantity)
	{
		var result = await _httpClient.PutAsJsonAsync("https://localhost:5004/api/OrderItems/update-quantity", editQuantity);
		return result.IsSuccessStatusCode;
	}
}
