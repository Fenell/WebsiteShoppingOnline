using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.BLL.DataTransferObjects.SizeDTO.Requests;
using ShoppingOnline.BLL.Features.SizeFeature;

namespace ShoppingOnline.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SizesController : ControllerBase
{
	private readonly ISizeService _sizeService;

	public SizesController(ISizeService sizeService)
	{
		_sizeService = sizeService;
	}
	[HttpGet]
	[Route("Get-all")]
	public async Task<IActionResult> GetAllSizes()
	{
		var result = await _sizeService.GetAllSize();
		return Ok(result);
	}

	[HttpGet]
	[Route("Get-by-{id}")]
	public async Task<IActionResult> GetBySize(Guid id) 
	{
		var result = await _sizeService.GetByIdSize(id);
		return Ok(result);
	}

	[HttpPost]
	[Route("Post")]
	public async Task<IActionResult> CreateSize(SizeCreateRequest request)
	{
		var result = await _sizeService.CreateSize(request);
		return Ok(result);
	}

	[HttpPut]
	[Route("put-by-{id}")]
	public async Task<IActionResult> Update(Guid id,SizeUpdateRequest request)
	{
		if(id == request.Id) 
		{
			await _sizeService.UpdateSize(id,request);
			return Ok();
		}
		else
		{
			return NotFound();
		}
	}

	[HttpDelete]
	[Route("Delete-by-{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		await _sizeService.DeleteSize(id);
		return Ok();
	}
}
