using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.BLL.Dtos.ProductViewModel;
using ShoppingOnline.BLL.Features.ProductApplication;
using ShoppingOnline.DAL.Entities;

namespace ShoppingOnline.API.Controllers;
[Route("api/[controller]")]
[ApiController]
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
	[Route("productId")]
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
	[HttpDelete]
	public async Task<IActionResult> DeleteProduct(DeleteProduct deleteProduct)
	{
		var request = await _productServices.DeleteProduct(deleteProduct);
		return Ok(request);
	}
	[HttpDelete]
	[Route("delete-hard-{id}")]
	public async Task<IActionResult> DeleteHardProduct(DeleteProduct deleteProduct)
	{
		var request = await _productServices.DeleteHardProduct(deleteProduct);
		return Ok(request);
	}
}
