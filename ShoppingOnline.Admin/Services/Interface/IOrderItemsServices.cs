using ShoppingOnline.Admin.ViewModels.OrderItems;

namespace ShoppingOnline.Admin.Services.Interface;

public interface IOrderItemsServices
{
	Task<List<OrderItemsGet>> GetOrderItems();
	Task<OrderItemEditQuantity> GetOrderItemEditQuantity(Guid id);
	Task<bool> EditQuantity(OrderItemEditQuantity editQuantity);
}
