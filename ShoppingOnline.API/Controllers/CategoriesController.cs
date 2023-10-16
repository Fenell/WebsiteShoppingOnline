using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.BLL.DataTransferObjects.CategoryDTO.Request;
using ShoppingOnline.BLL.Features.CategoryFeature;

namespace ShoppingOnline.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
	private readonly ICategoryService _categoryService;

	public CategoriesController(ICategoryService categoryService)
	{
		_categoryService = categoryService;
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		var objColection = await _categoryService.GetAll();

		return Ok(objColection);
	}

	[HttpGet]
	[Route("get-by-id-{id}")]
	public async Task<IActionResult> Get(Guid id)
	{
		var obj = await _categoryService.GetById(id);
		return Ok(obj);
	}

	[HttpPost]
	public async Task<IActionResult> Create(CategoryCreateRequest request)
	{
		var result = await _categoryService.CreateCategory(request);

		return Ok(result);
	}

	[HttpPut]
	[Route("put-by-id-{id}")]
	public async Task<IActionResult> Update(Guid id, CategoryUpdateRequest request)
	{
		if (id != request.Id)
		{
			return NotFound();
		}
		await _categoryService.UpdateCategory(id, request);
		return Ok();
	}

	[HttpDelete]
	[Route("Delete-by-id-{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		await _categoryService.DeleteCategory(id);
		return Ok();
	}

}
