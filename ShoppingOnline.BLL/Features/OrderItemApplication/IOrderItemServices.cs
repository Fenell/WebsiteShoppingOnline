using ShoppingOnline.BLL.Dtos.OrderItemViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Features.OrderItemApplication;
public interface IOrderItemServices
{
	Task<IEnumerable<GetOrderItems>> GetAllOrderItems();
	Task<GetOrderItems> GetOrderItemsById(Guid id);
	Task<bool> UpdateOrderItem(UpdateOrderItem item);
	Task<Guid> CreatedOrderItem(CreatedOrderItem item);
	Task<bool> DeleteOrderItem(DeleteOrderItem deleteOrderItem);
}
