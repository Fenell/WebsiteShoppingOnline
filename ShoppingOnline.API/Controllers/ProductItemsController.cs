using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.BLL.DataTransferObjects.ProductItemDTO.Requests;
using ShoppingOnline.BLL.Features.ProductItemFeature;

namespace ShoppingOnline.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
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
	[Route("{id}")]
	public async Task<IActionResult> GetProductItemsById(Guid id)
	{
		var request = await _services.GetProductItemById(id);
		return Ok(request);
	}

	[HttpGet]
	[Route("product-item-id")]
	public async Task<IActionResult> GetProductItemsChienById(Guid id)
	{
		var request = await _services.GetProductItemChienById(id);
		return Ok(request);
	}

	[HttpGet]
	[Route("get-all/{productId}")]
	public async Task<IActionResult> GetPoductItemWithProductId(Guid productId)
	{
		var result = await _services.GetProductItemWithProductId(productId);

		return Ok(result);
	}

	[HttpPost]
	[Route("creat-list/{productId}")]
	public async Task<IActionResult> CreateListProductItem(Guid productId, List<ProductItemCreateRequest> requests)
	{
		var isSuccess = await _services.CreateListProductItem(productId, requests);

		if (isSuccess)
			return Ok();
		return BadRequest();
	}

	[HttpPut]
	public async Task<IActionResult> UpdateProductItems(UpdateProductItem updateProductItem)
	{
		var request = await _services.UpdateProductItem(updateProductItem);

		if (request)
			return Ok();
		return BadRequest();

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