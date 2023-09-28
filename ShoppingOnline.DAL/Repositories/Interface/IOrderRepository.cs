using ShoppingOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Repositories.Interface;
public interface IOrderRepository : IGenericRepository<Order>
{
	Task<IEnumerable<Order>> GetAllOrders();
	Task<Order> GetOrderById(Guid id);
	Task<Guid> CreateOrder(Order order);
	Task<bool> UpdateOrder(Order order);
	Task<bool> DeleteOrder(Order order);
}
