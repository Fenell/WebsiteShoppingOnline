using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.BLL.DataTransferObjects.BrandItemDTO;
using ShoppingOnline.BLL.DataTransferObjects.ColorDTO.Requests;
using ShoppingOnline.BLL.Features.BrandFeature;
using ShoppingOnline.BLL.Features.ColorFeature;

namespace ShoppingOnline.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class BrandsController : ControllerBase
{

	private readonly IBrandServices _brandService;

	public BrandsController(IBrandServices brandServices)
	{
		_brandService = brandServices;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllBrand()
	{
		var result = await _brandService.GetAllBrands();

		return Ok(result);
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreatedBrand request)
	{

		var result = await _brandService.CreatedBrand(request);

		return Ok(result);
	}

	[HttpGet]
	[Route("get-by-id-{id}")]
	public async Task<IActionResult> GetBrandById(Guid id)
	{
		var result = await _brandService.GetBrandById(id);
		return Ok(result);
	}

	[HttpPut]
	[Route("put-by-id-{id}")]
	public async Task<IActionResult> Update(Guid id, UpdateBrand request)
	{
		if (id != request.Id)
		{
			return NotFound();
		}
		await _brandService.UpdateBrand(id, request);
		return Ok();
	}

	[HttpDelete]
	[Route("Delete-by-id-{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		await _brandService.DeleteBrand(id);
		return Ok();
	}
}