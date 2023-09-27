using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.BLL.Features.ProductApplication;

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
}
