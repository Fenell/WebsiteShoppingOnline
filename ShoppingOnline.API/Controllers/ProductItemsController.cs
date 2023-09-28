using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.BLL.Dtos.ProductItemViewModel;
using ShoppingOnline.BLL.Features.ProductItemApplication;

namespace ShoppingOnline.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductItemsController : ControllerBase
{
	private readonly IProductItemServices _services;
	public ProductItemsController(IProductItemServices services)
	{
		_services = services;
	}
	[HttpGet]
	public async Task<IActionResult> GetProductItems()
	{
		var productItems = await _services.GetProductItems();
		return Ok(productItems);
	}
	[HttpGet]
	[Route("product-item-id")]
	public async Task<IActionResult> GetProductItemsById(Guid id)
	{
		var request = await _services.GetProductItemById(id);
		return Ok(request);
	}
	[HttpPut]
	public async Task<IActionResult> UpdateProductItems(UpdateProductItem updateProductItem)
	{
		var request = await _services.UpdateProductItem(updateProductItem);
		return Ok(request);
	}
	[HttpDelete]
	public async Task<IActionResult> DeleteProductItem(DeleteProductItem deleteProductItem)
	{
		var request = await _services.DeleteProductItem(deleteProductItem);
		return Ok(request);
	}
	[HttpDelete]
	[Route("delete-hard-{id}")]
	public async Task<IActionResult> DeleteHardProductItem(DeleteProductItem deleteProductItem)
	{
		var request = await _services.DeleteHardProductItem(deleteProductItem);
		return Ok(request);
	}
}
