using ShoppingOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Repositories.Interface;
public interface IOrderItemRepository : IGenericRepository<OrderItem>
{
	Task<IEnumerable<OrderItem>> GetAllOrderItem();
	Task<OrderItem> GetOrderItemById(Guid id);
	Task<bool> UpdateOrderIte(OrderItem item);
	Task<Guid> CreatedOrderItem(OrderItem item);
}
