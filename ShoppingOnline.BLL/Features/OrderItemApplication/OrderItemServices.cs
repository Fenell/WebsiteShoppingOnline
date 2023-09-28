using AutoMapper;
using ShoppingOnline.BLL.Dtos.OrderItemViewModel;
using ShoppingOnline.BLL.Exceptions;
using ShoppingOnline.DAL.Database.AppDbContext;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Features.OrderItemApplication;
public class OrderItemServices : IOrderItemServices
{
	private readonly IOrderItemRepository _orderItemRepository;
	private readonly IMapper _mapper;
	public OrderItemServices(IOrderItemRepository orderItemRepository, IMapper mapper)
	{
		_orderItemRepository = orderItemRepository;
		_mapper = mapper;
	}

	public async Task<Guid> CreatedOrderItem(CreatedOrderItem item)
	{
		var requestMap = _mapper.Map<CreatedOrderItem, OrderItem>(item);
		var request = await _orderItemRepository.CreateAsync(requestMap);
		return requestMap.Id;
	}

	public async Task<IEnumerable<GetOrderItems>> GetAllOrderItems()
	{
		var request = await _orderItemRepository.GetAllAsync();
		var requestMap = _mapper.Map<IEnumerable<GetOrderItems>>(request);
		return requestMap;
	}

	public async Task<GetOrderItems> GetOrderItemsById(Guid id)
	{
		var repuest = await _orderItemRepository.GetByIdAsync(id);
		var requestMap = _mapper.Map<GetOrderItems>(repuest);
		return requestMap;
	}

	public async Task<bool> UpdateOrderItem(UpdateOrderItem item)
	{
		var orderItem = await _orderItemRepository.GetByIdAsync(item.Id);

		if (orderItem == null)
			throw new NotFoundException(nameof(orderItem), item.Id);

		orderItem.Quantity = item.Quantity;
		orderItem.UpdateAt = DateTime.Now;

		return await _orderItemRepository.UpdateAsync(orderItem);
	}
}
