using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.API.DTO;
using ShoppingOnline.DAL.Constants;
using ShoppingOnline.DAL.Database.AppDbContext;
using ShoppingOnline.DAL.Entities;
using System.Security.Cryptography.X509Certificates;

namespace ShoppingOnline.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductImgsController : ControllerBase
{
	public readonly ApplicationDbContext _appContext;
	public ProductImgsController(ApplicationDbContext context)
	{
		_appContext = context;
	}
		
		
	[HttpGet ("getall product img")] 
	public IEnumerable<ProductImage> GetAll()
	{
		return _appContext.ProductImages.ToList();
	}
	[HttpGet("{id}")]
	public  ProductImage GetById(Guid id)
	{
		return _appContext.ProductImages.Find(id);
	}
	[HttpPost]

	public bool PostByParams(Guid ProducItemtId, string ImageUrl, string Status, int Position)
	{
		Guid id = Guid.NewGuid();
		ProductImage productImg = new ProductImage
		{
			ProducItemtId = ProducItemtId,
			ImageUrl = ImageUrl,
			Position = Position,
			Status =Status,
			CreatedAt = DateTime.Now
		};
		try
		{
			_appContext.ProductImages.Add(productImg);
			_appContext.SaveChanges();
			return true;
		}
		catch (Exception)
		{
			return false;
		}
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
