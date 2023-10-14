using AutoMapper;
using ShoppingOnline.BLL.DataTransferObjects.OrderDTO;
using ShoppingOnline.BLL.DataTransferObjects.ProductItemDTO;
using ShoppingOnline.BLL.Exceptions;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;
using System.Net;

namespace ShoppingOnline.BLL.Features.OrderFeature;
public class OrderServices : IOrderServices
{
	private readonly IOrderRepository _orderRepository;
	private readonly IMapper _mapper;
	private readonly IOrderItemRepository _orderItemRepository;
	private readonly IProductItemRepository _productItemRepository;

	public OrderServices(IOrderRepository orderRepository, IMapper mapper, IOrderItemRepository orderItemRepository, IProductItemRepository productItemRepository)
	{
		_orderRepository = orderRepository;
		_mapper = mapper;
		_orderItemRepository = orderItemRepository;
		_productItemRepository = productItemRepository;
	}

	public async Task<Guid> CreatedOrder(CreatedOrder createdOrder)
	{
		var request = new Order()
		{
			PromotionId = createdOrder.PromotionId,
			CustomerName = createdOrder.CustomerName,
			Address = createdOrder.Address,
			PhoneNumber = createdOrder.PhoneNumber,
			Note = createdOrder.Note,
			Total = createdOrder.Total,
		};
		var idOrder = await _orderRepository.CreateOrder(request);

		List<OrderItem> lstOrder = new List<OrderItem>();
		foreach (var item in createdOrder.OrderItems)
		{
			var orderItem = new OrderItem()
			{
				OrderId = idOrder,
				ProductItemId = item.ProductItemId,
				Quantity = item.Quantity,
				Price = item.Price,
			};
			lstOrder.Add(orderItem);
		}

		await _orderItemRepository.CreateRangeAsync(lstOrder);

		List<UpdateProductItem> updateProductItems = new List<UpdateProductItem>();
		foreach (var item in lstOrder)
		{
			var productItem = await _productItemRepository.GetProductItemById(item.ProductItemId);
			productItem.Quantity -= item.Quantity;
			await _productItemRepository.UpdateProductItem(productItem);
		}


		return request.Id;
	}

	public async Task<bool> DeleteHardOrder(DeleteOrder deletedOrder)
	{
		var request = await _orderRepository.GetByIdAsync(deletedOrder.Id);

		if (request == null)
			throw new NotFoundException(nameof(request), deletedOrder.Id);

		return await _orderRepository.DeleteAsync(request);
	}

	public async Task<bool> UpdateOrderStatus(UpdateStatus updateStatus)
	{
		var order = await _orderRepository.GetOrderById(updateStatus.Id);

		if (order == null)
			throw new NotFoundException(nameof(order), updateStatus.Id);

		var orderMap = _mapper.Map<UpdateStatus, Order>(updateStatus, order);

		await _orderRepository.UpdateOrder(orderMap);

		if (updateStatus.OrderStatus == "CANCEL")
		{
			var productItem = await _productItemRepository.GetProductItemById(updateStatus.IdProductItems);
			productItem.Quantity += updateStatus.Quantity;
			return await _productItemRepository.UpdateAsync(productItem);
		}
		return true;
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
