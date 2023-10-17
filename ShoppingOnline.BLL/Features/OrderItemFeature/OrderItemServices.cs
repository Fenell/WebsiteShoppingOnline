using AutoMapper;
using ShoppingOnline.BLL.DataTransferObjects.OrderItemDTO;
using ShoppingOnline.BLL.Exceptions;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;

namespace ShoppingOnline.BLL.Features.OrderItemFeature;
public class OrderItemServices : IOrderItemServices
{
	private readonly IOrderItemRepository _orderItemRepository;
	private readonly IMapper _mapper;
	private readonly IProductItemRepository _productItemRepository;
	private readonly IOrderRepository _orderRepository;

	public OrderItemServices(IOrderItemRepository orderItemRepository, IMapper mapper, IProductItemRepository productItemRepository, IOrderRepository orderRepository)
	{
		_orderItemRepository = orderItemRepository;
		_mapper = mapper;
		_productItemRepository = productItemRepository;
		_orderRepository = orderRepository;
	}

	public async Task<Guid> CreatedOrderItem(CreatedOrderItem item)
	{
		var requestMap = _mapper.Map<CreatedOrderItem, OrderItem>(item);
		var request = await _orderItemRepository.CreateAsync(requestMap);
		return requestMap.Id;
	}

	public async Task<bool> DeleteHardOrderItem(DeleteOrderItem deletedHardOrderItem)
	{
		var request = await _orderItemRepository.GetByIdAsync(deletedHardOrderItem.Id);
		if (request == null)
			throw new NotFoundException(nameof(request), deletedHardOrderItem.Id);

		return await _orderItemRepository.DeleteAsync(request);
	}

	public async Task<bool> EditOrderItem(OrderItemEdit orderItemEdit)
	{
		var request = await _orderItemRepository.GetByIdAsync(orderItemEdit.Id);
		var QuantityDau = request.Quantity;
		request.Quantity = orderItemEdit.Quantity;
		await _orderItemRepository.UpdateAsync(request);

		var requestProduct = await _productItemRepository.GetByIdAsync(request.ProductItemId);
		requestProduct.Quantity -= (orderItemEdit.Quantity - QuantityDau);
		requestProduct.ColorId = orderItemEdit.ColorId;
		requestProduct.SizeId = orderItemEdit.SizeId;
		await _productItemRepository.UpdateAsync(requestProduct);

		var order = await _orderRepository.GetOrderById(request.OrderId);
		var orderItems = await _orderItemRepository.GetAllAsync();
		foreach (var item in orderItems)
		{
			if (order.Id == item.OrderId)
			{
				order.Total = 0;
				order.Total += (item.Quantity * item.Price);
			}
		}
		return await _orderRepository.UpdateAsync(order);
	}

	public async Task<bool> DeleteOrderItem(DeleteOrderItem deleteOrderItem)
	{
		var request = await _orderItemRepository.GetByIdAsync(deleteOrderItem.Id);
		if (request == null)
			throw new NotFoundException(nameof(request), deleteOrderItem.Id);

		request.IsDeleted = true;
		return await _orderItemRepository.DeleteOrderItem(request);
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

		return await _orderItemRepository.UpdateAsync(orderItem);
	}
}
