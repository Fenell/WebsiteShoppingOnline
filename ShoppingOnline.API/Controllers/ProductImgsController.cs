using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

	//public Guid ProducItemtId { get; set; }
	//public string? ImageUrl { get; set; }
	//public int Position { get; set; }
	//public string Status { get; set; } = EntityStatus.Active;
	//public virtual ProductItem? ProductItem { get; set; }
	public bool PostByParams(string ImageUrl, string Status, int Position)
	{
		Guid id = Guid.NewGuid();
		ProductImage sinhvien = new ProductImage
		{
			ProducItemtId = id,
			ImageUrl = ImageUrl,
			Position = Position,
			Status =Status
};
		try
		{
			_appContext.ProductImages.Add(sinhvien);
			_appContext.SaveChanges();
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}
	[HttpPut("{id}")]
	public bool Update(Guid id)
	{
		try
		{
			ProductImage productIMG = _appContext.ProductImages.Find(id);
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
