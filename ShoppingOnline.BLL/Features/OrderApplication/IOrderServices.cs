using ShoppingOnline.BLL.Dtos.OrderViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Features.OrderApplication;
public interface IOrderServices
{
	Task<IEnumerable<GetOrder>> GetOrders();
	Task<GetOrder> GetOrderById(Guid id);
	Task<Guid> CreatedOrder(CreatedOrder createdOrder);
	Task<bool> UpdateOrder(UpdateOrder updateOrder);
	Task<bool> DeleteOrder(DeleteOrder deleteOrder);
}
