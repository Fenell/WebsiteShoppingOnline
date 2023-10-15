using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingOnline.API.DTO;
using ShoppingOnline.DAL.Database.AppDbContext;
using ShoppingOnline.DAL.Entities;

namespace ShoppingOnline.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductImgsController : ControllerBase
{
	public readonly ApplicationDbContext _appContext;
	private readonly IWebHostEnvironment _webHostEnvironment;

	public ProductImgsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
	{
		_appContext = context;
		_webHostEnvironment = webHostEnvironment;
	}

	[HttpGet("get-by-productItem/{productItemId}")]
	public IEnumerable<ProductImage> GetAll(Guid productItemId)
	{
		return _appContext.ProductImages.AsNoTracking().Where(c => c.ProducItemtId == productItemId);
	}

	[HttpGet("{id}")]
	public ProductImage GetById(Guid id)
	{
		return _appContext.ProductImages.Find(id);
	}

	[HttpPost]
	[Route("add-list/{productItemId}")]
	[Consumes("multipart/form-data")]
	public async Task<IActionResult> PostByParams([FromRoute] Guid productItemId, [FromForm] List<IFormFile> files)
	{
		var lstProductImage = await _appContext.ProductImages.Where(c => c.ProducItemtId == productItemId).ToListAsync();
		foreach (var item in lstProductImage)
		{
			if (System.IO.File.Exists(_webHostEnvironment.WebRootPath + item.ImageUrl))
			{
				System.IO.File.Delete(_webHostEnvironment.WebRootPath + item.ImageUrl);
			}
		}
		_appContext.ProductImages.RemoveRange(lstProductImage);
		await _appContext.SaveChangesAsync();

		List<ProductImage> productImages = new();
		if (files.Any())
		{
			foreach (IFormFile file in files)
			{
				FileInfo fileInfo = new FileInfo(file.FileName);
				string fileName = Guid.NewGuid() + fileInfo.Extension;
				var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
				await using (var fileStream = new FileStream(path, FileMode.OpenOrCreate))
				{
					await file.CopyToAsync(fileStream);
				}
				var imgUrl = "/images/" + fileName;
				var productImage = new ProductImage()
				{
					ImageUrl = imgUrl,
					ProducItemtId = productItemId,
					Position = 1,
					CreatedAt = DateTime.Now,
				};
				productImages.Add(productImage);
			}

			await _appContext.ProductImages.AddRangeAsync(productImages);
			return await _appContext.SaveChangesAsync() > 0 ? Ok() : BadRequest();
		}

		return BadRequest();
	}

	[HttpPut("{id}")]
	public bool Update(UpdateProductIMG productImage)
	{
		ProductImage productIMG = _appContext.ProductImages.Find(productImage.Id);
		try
		{
			productIMG.ImageUrl = productImage.ImageUrl;
			productIMG.Position = productImage.Position;
			//productIMG.Status = productImage.Status;
			productIMG.UpdateAt = DateTime.Now;
			_appContext.ProductImages.Update(productIMG);
			_appContext.SaveChanges();
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}
	[HttpDelete("{id}")]
	public bool Delete(Guid id)
	{
		try
		{
			ProductImage productIMG = _appContext.ProductImages.Find(id);

			_appContext.ProductImages.Remove(productIMG);
			_appContext.SaveChanges();
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}


}
