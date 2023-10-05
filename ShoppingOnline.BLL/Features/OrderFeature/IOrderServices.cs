using ShoppingOnline.BLL.DataTransferObjects.OrderDTO;

namespace ShoppingOnline.BLL.Features.OrderFeature;
public interface IOrderServices
{
	Task<IEnumerable<GetOrder>> GetOrders();
	Task<GetOrder> GetOrderById(Guid id);
	Task<Guid> CreatedOrder(CreatedOrder createdOrder);
	Task<bool> UpdateOrder(UpdateOrder updateOrder);
	Task<bool> DeleteOrder(DeleteOrder deleteOrder);
	Task<bool> DeleteHardOrder(DeleteOrder deletedOrder);
}
