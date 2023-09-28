using ShoppingOnline.DAL.Database.AppDbContext;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Repositories.Implement;
public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
	private readonly IGenericRepository<Order> _genericRepository;
	public OrderRepository(ApplicationDbContext context, IGenericRepository<Order> genericRepository) : base(context)
	{
		_genericRepository = genericRepository;
	}

	public async Task<Guid> CreateOrder(Order order)
	{
		try
		{
			var request = await _genericRepository.CreateAsync(order);
			return order.Id;
		}
		catch (Exception)
		{
			throw;
		}
	}

	public async Task<IEnumerable<Order>> GetAllOrders()
	{
		return await _genericRepository.GetAllAsync();
	}

	public async Task<Order> GetOrderById(Guid id)
	{
		return await _genericRepository.GetByIdAsync(id);
	}

	public async Task<bool> UpdateOrder(Order order)
	{
		try
		{
			var request = await _genericRepository.UpdateAsync(order);
			return request;
		}
		catch (Exception)
		{
			return false;
			throw;
		}
	}
}
