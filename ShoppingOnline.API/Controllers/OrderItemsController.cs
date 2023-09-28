using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.BLL.Dtos.OrderItemViewModel;
using ShoppingOnline.BLL.Dtos.ProductViewModel;
using ShoppingOnline.BLL.Features.OrderItemApplication;

namespace ShoppingOnline.API.Controllers;
[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class OrderItemsController : ControllerBase
{
	private readonly IOrderItemServices _orderItemServices;
	public OrderItemsController(IOrderItemServices orderItemServices)
	{
		_orderItemServices = orderItemServices;
	}
	[HttpGet]
	public async Task<IActionResult> GetAllOrderItems()
	{
		var result = await _orderItemServices.GetAllOrderItems();
		return Ok(result);
	}
	[HttpGet]
	[Route("order-item-by-id")]
	public async Task<IActionResult> GetOrderItemById(Guid id)
	{
		var result = await _orderItemServices.GetOrderItemsById(id);
		return Ok(result);
	}
	[HttpPut]
	public async Task<IActionResult> UpdateOrderItem(UpdateOrderItem updateOrderItem)
	{
		var result = await _orderItemServices.UpdateOrderItem(updateOrderItem);
		return Ok(result);
	}
	[HttpDelete]
	public async Task<IActionResult> DeleteOrderItem(DeleteOrderItem deleteOrderItem)
	{
		var request = await _orderItemServices.DeleteOrderItem(deleteOrderItem);
		return Ok(request);
	}
	[HttpDelete]
	[Route("delete-hard-{id}")]
	public async Task<IActionResult> DeleteHardOrderItem(DeleteOrderItem delHardOrderItem)
	{
		var request = await _orderItemServices.DeleteOrderItem(delHardOrderItem);
		return Ok(request);
	}
	[HttpPost]
	public async Task<IActionResult> CreatedOrderItem(CreatedOrderItem createdOrderItem)
	{
		var request = await _orderItemServices.CreatedOrderItem(createdOrderItem);
		var requestNew = await _orderItemServices.GetOrderItemsById(request);
		return CreatedAtAction(nameof(GetOrderItemById), request, requestNew);
	}
}
