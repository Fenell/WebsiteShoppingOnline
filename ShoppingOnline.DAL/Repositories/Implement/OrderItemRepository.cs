using ShoppingOnline.DAL.Database.AppDbContext;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Repositories.Implement;
public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
	private readonly IGenericRepository<OrderItem> _genericRepository;
	public OrderItemRepository(ApplicationDbContext context, IGenericRepository<OrderItem> genericRepository) : base(context)
	{
		_genericRepository = genericRepository;
	}

	public async Task<Guid> CreatedOrderItem(OrderItem item)
	{
		try
		{
			var request = await _genericRepository.CreateAsync(item);
			return item.Id;
		}
		catch (Exception)
		{

			throw;
		}
	}

	public async Task<bool> DeleteOrderItem(OrderItem orderItem)
	{
		try
		{
			var request = await _genericRepository.UpdateAsync(orderItem);
			return request;
		}
		catch (Exception)
		{
			return false;
			throw;
		}
	}

	public async Task<IEnumerable<OrderItem>> GetAllOrderItem()
	{
		return await _genericRepository.GetAllAsync();
	}

	public async Task<OrderItem> GetOrderItemById(Guid id)
	{
		return await _genericRepository.GetByIdAsync(id);
	}

	public async Task<bool> UpdateOrderIte(OrderItem item)
	{
		try
		{
			return await _genericRepository.UpdateAsync(item);
		}
		catch (Exception)
		{
			return false;
			throw;
		}
	}
}
