using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.BLL.Dtos.OrderViewModel;
using ShoppingOnline.BLL.Features.OrderApplication;

namespace ShoppingOnline.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
	private readonly IOrderServices _orderServices;
	public OrdersController(IOrderServices orderServices)
	{
		_orderServices = orderServices;
	}
	[HttpGet]
	public async Task<IActionResult> GetAllOrders()
	{
		var result = await _orderServices.GetOrders();
		return Ok(result);
	}
	[HttpGet]
	[Route("order-by-id")]
	public async Task<IActionResult> GetOrderById(Guid id)
	{
		var result = await _orderServices.GetOrderById(id);
		return Ok(result);
	}
	[HttpPost]
	public async Task<IActionResult> CreatedOrder(CreatedOrder createdOrder)
	{
		var request = await _orderServices.CreatedOrder(createdOrder);

		var newOrder = await _orderServices.GetOrderById(request);

		return CreatedAtAction(nameof(GetOrderById), request, newOrder);
	}
	[HttpPut]
	public async Task<IActionResult> UpdateOrder(UpdateOrder updateOrder)
	{
		var request = await _orderServices.UpdateOrder(updateOrder);
		return Ok(request);
	}
	[HttpDelete]
	public async Task<IActionResult> DeleteOrder(DeleteOrder deleteOrder)
	{
		var request = await _orderServices.DeleteOrder(deleteOrder);
		return Ok(request);
	}
	[HttpDelete]
	[Route("delete-hard-{id}")]
	public async Task<IActionResult> DeleteHardOrder(DeleteOrder deleteOrder)
	{
		var request = await _orderServices.DeleteHardOrder(deleteOrder);
		return Ok(request);
	}
}
