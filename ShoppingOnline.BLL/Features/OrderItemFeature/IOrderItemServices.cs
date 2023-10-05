using ShoppingOnline.BLL.DataTransferObjects.OrderItemDTO;

namespace ShoppingOnline.BLL.Features.OrderItemFeature;
public interface IOrderItemServices
{
	Task<IEnumerable<GetOrderItems>> GetAllOrderItems();
	Task<GetOrderItems> GetOrderItemsById(Guid id);
	Task<bool> UpdateOrderItem(UpdateOrderItem item);
	Task<Guid> CreatedOrderItem(CreatedOrderItem item);
	Task<bool> DeleteOrderItem(DeleteOrderItem deleteOrderItem);
	Task<bool> DeleteHardOrderItem(DeleteOrderItem deletedHardOrderItem);
}
