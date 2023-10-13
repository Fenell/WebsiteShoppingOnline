using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.BLL.DataTransferObjects.ProductDTO;
using ShoppingOnline.BLL.DataTransferObjects.ProductDTO.Requests;
using ShoppingOnline.BLL.Features.ProductFeature;
using ShoppingOnline.DAL.Entities;

namespace ShoppingOnline.API.Controllers;
[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class ProductsController : ControllerBase
{
	private readonly IProductServices _productServices;
	public ProductsController(IProductServices productServices)
	{
		_productServices = productServices;
	}

	[HttpGet]
	public async Task<IActionResult> GetProduct()
	{
		var result = await _productServices.GetAllProducts();
		return Ok(result);
	}

	[HttpGet]
	[Route("{productId}")]
	public async Task<IActionResult> GetProductById(Guid productId)
	{
		var result = await _productServices.GetProductById(productId);
		return Ok(result);
	}

	[HttpPost]
	public async Task<IActionResult> CreatedProduct(CreateProduct createProduct)
	{
		var request = await _productServices.CreateProduct(createProduct);

		var newProduct = await _productServices.GetProductById(request);
		return CreatedAtAction(nameof(GetProductById), request, newProduct);
	}

	[HttpPut]
	public async Task<IActionResult> UpdateProduct(UpdateProduct updateProduct)
	{
		var request = await _productServices.UpdateProduct(updateProduct);
		return Ok(request);
	}

	[HttpPatch]
	[Route("{id}")]
	public async Task<IActionResult> ChangeStatus(Guid id)
	{
		var request = new StatusChangeRequest() { Id = id };
		var result = await _productServices.SwitchStatusProduct(request);

		return Ok(request);
	}

	[HttpDelete]
	[Route("delete-hard-{id}")]
	public async Task<IActionResult> DeleteHardProduct(StatusChangeRequest deleteProduct)
	{
		var request = await _productServices.DeleteHardProduct(deleteProduct);
		return Ok(request);
	}
}
