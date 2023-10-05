using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.BLL.DataTransferObjects.ColorDTO.Requests;
using ShoppingOnline.BLL.Exceptions;
using ShoppingOnline.BLL.Features.ColorFeature;

namespace ShoppingOnline.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ColorsController : ControllerBase
{
	private readonly IColorService _colorService;

	public ColorsController(IColorService colorService)
	{
		_colorService = colorService;
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		var result = await _colorService.GetAll();

		return Ok(result);
	}

	[HttpPost]
	public async Task<IActionResult> Create(ColorCreateRequest request)
	{
		
		var result = await _colorService.CreateColor(request);
		
		return Ok(result);
	}

	[HttpGet]
	[Route("get-by-id-{id}")]
	public async Task<IActionResult> GetByIdColor(Guid id)
	{
		var result = await _colorService.GetById(id);
		return Ok(result);
	}

	[HttpPut]
	[Route("put-by-id-{id}")]
	public async Task<IActionResult> Update(Guid id,ColorUpdateRequest request) 
	{
		if(id != request.Id)
		{
			return NotFound();
		}
		await _colorService.UpdateColor(id, request);
		return Ok();
	}

	[HttpDelete]
	[Route("Delete-by-id-{id}")]
	public async Task<IActionResult> Delete(Guid id) 
	{
		await _colorService.DeleteColor(id);
		return Ok();
	}
}
