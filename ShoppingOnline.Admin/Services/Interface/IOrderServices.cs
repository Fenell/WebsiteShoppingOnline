using ShoppingOnline.Admin.ViewModels.Order;

namespace ShoppingOnline.Admin.Services.Interface;

public interface IOrderServices
{
	Task<List<OrderGetDtos>> GetOrdersAsync();
	Task<bool> EditOrderStatus(OrderStatusDtos orderStatus);
	Task<OrderGetDtos> GetOrderById(Guid Id);
}
