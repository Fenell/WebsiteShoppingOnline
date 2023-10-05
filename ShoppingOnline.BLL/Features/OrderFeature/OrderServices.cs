using AutoMapper;
using ShoppingOnline.BLL.DataTransferObjects.OrderDTO;
using ShoppingOnline.BLL.Exceptions;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;

namespace ShoppingOnline.BLL.Features.OrderFeature;
public class OrderServices : IOrderServices
{
	private readonly IOrderRepository _orderRepository;
	private readonly IMapper _mapper;
	public OrderServices(IOrderRepository orderRepository, IMapper mapper)
	{
		_orderRepository = orderRepository;
		_mapper = mapper;
	}

	public async Task<Guid> CreatedOrder(CreatedOrder createdOrder)
	{
		var request = _mapper.Map<CreatedOrder, Order>(createdOrder);
		request.Total = createdOrder.Quantity * createdOrder.Price;

		await _orderRepository.CreateOrder(request);

		return request.Id;
	}

	public async Task<bool> DeleteHardOrder(DeleteOrder deletedOrder)
	{
		var request = await _orderRepository.GetByIdAsync(deletedOrder.Id);

		if (request == null)
			throw new NotFoundException(nameof(request), deletedOrder.Id);

		return await _orderRepository.DeleteAsync(request);
	}

	public async Task<bool> DeleteOrder(DeleteOrder deleteOrder)
	{
		var request = await _orderRepository.GetByIdAsync(deleteOrder.Id);

		if (request == null)
			throw new NotFoundException(nameof(request), deleteOrder.Id);

		request.IsDeleted = true;
		return await _orderRepository.DeleteOrder(request);
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
