using AutoMapper;
using ShoppingOnline.BLL.Dtos.OrderItemViewModel;
using ShoppingOnline.BLL.Dtos.OrderViewModel;
using ShoppingOnline.BLL.Exceptions;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Features.OrderApplication;
public class OrderServices : IOrderServices
{
	private readonly IOrderRepository _orderRepository;
	private readonly IOrderItemRepository _itemRepository;
	private readonly IMapper _mapper;
	public OrderServices(IOrderRepository orderRepository, IMapper mapper, IOrderItemRepository itemRepository)
	{
		_orderRepository = orderRepository;
		_mapper = mapper;
		_itemRepository = itemRepository;
	}

	public async Task<Guid> CreatedOrder(CreatedOrder createdOrder)
	{
		var request = _mapper.Map<CreatedOrder, Order>(createdOrder);
		request.Total = createdOrder.Quantity * createdOrder.Price;

		await _orderRepository.CreateOrder(request);

		foreach (var item in request.OrderItems)
		{
			item.ProductItemId = request.Id;
			item.Quantity = createdOrder.Quantity;
			item.Price = createdOrder.Price;
			await _itemRepository.CreatedOrderItem(item);
		}
		return request.Id;
	}

	public async Task<GetOrder> GetOrderById(Guid id)
	{
		var request = await _orderRepository.GetByIdAsync(id);
		if (request == null)
			throw new NotFoundException(nameof(request), id);
		var orderMap = _mapper.Map<GetOrder>(request);
		return orderMap;
	}

	public async Task<IEnumerable<GetOrder>> GetOrders()
	{
		var orders = await _orderRepository.GetAllOrders();
		var ordersMap = _mapper.Map<IEnumerable<GetOrder>>(orders);
		return ordersMap;
	}

	public async Task<bool> UpdateOrder(UpdateOrder updateOrder)
	{
		var order = await _orderRepository.GetOrderById(updateOrder.Id);

		if (order == null)
			throw new NotFoundException(nameof(order), updateOrder.Id);

		var orderMap = _mapper.Map<UpdateOrder, Order>(updateOrder, order);

		return await _orderRepository.UpdateOrder(orderMap);
	}
}
