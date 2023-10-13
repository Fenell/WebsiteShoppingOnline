using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.BLL.DataTransferObjects.BrandItemDTO;
using ShoppingOnline.BLL.Features.BrandFeature;

namespace ShoppingOnline.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class BrandsController : ControllerBase
{
	private readonly IBrandServices _brandServices;

	public BrandsController(IBrandServices brandServices)
	{
		_brandServices = brandServices;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllBrands()
	{
		var request = await _brandServices.GetAllBrands();
		return Ok(request);
	}

	[HttpGet]
	[Route("brand-by-{id}")]
	public async Task<IActionResult> GetBrandById(Guid id)
	{
		var request = await _brandServices.GetBrandById(id);
		return Ok(request);
	}

	[HttpPost]
	public async Task<IActionResult> CreatedBrand(CreatedBrand createdBrand)
	{
		var request = await _brandServices.CreatedBrand(createdBrand);

		var requestNew = await _brandServices.GetBrandById(request);

		return CreatedAtAction(nameof(GetBrandById), requestNew, request);
	}

	[HttpPut]
	public async Task<IActionResult> UpdateBrand(UpdateBrand updateBrand)
	{
		var request = await _brandServices.UpdateBrand(updateBrand);
		return Ok(request);
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteBrand(GetBrand getBrand)
	{
		var request = await _brandServices.DeleteBrand(getBrand);
		return Ok(request);
	}
}