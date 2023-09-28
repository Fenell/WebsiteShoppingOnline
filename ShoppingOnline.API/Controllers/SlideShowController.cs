using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.API.DTO;
using ShoppingOnline.DAL.Database.AppDbContext;
using ShoppingOnline.DAL.Entities;

namespace ShoppingOnline.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SlideShowController : ControllerBase
{
	public readonly ApplicationDbContext _appContext;
	public SlideShowController(ApplicationDbContext context)
	{
		_appContext = context;
	}
	[HttpGet("getall product img")]
	public IEnumerable<SlideShow> GetAll()
	{
		return _appContext.SlideShows.ToList();
	}
	[HttpGet("{id}")]
	public SlideShow GetById(Guid id)
	{
		return _appContext.SlideShows.Find(id);
	}
	[HttpPost]

	public bool PostByParams(string ImageUrl, int Position , string LinkDetail)
	{
		Guid id = Guid.NewGuid();
		SlideShow slideShow = new SlideShow
		{
			Id = id,
			ImageUrl  = ImageUrl,
			LinkDetail = LinkDetail,
			Position = Position,
			CreatedAt = DateTime.Now
		};
		try
		{
			_appContext.SlideShows.Add(slideShow);
			_appContext.SaveChanges();
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}
	[HttpPut("{id}")]
	public bool Update(UpdateSlideShow slideShow)
	{
		SlideShow slideShow1 = _appContext.SlideShows.Find(slideShow.Id);
		try
		{

			slideShow1.Position = slideShow.Position;
			slideShow1.UpdateAt = DateTime.Now;
			_appContext.SlideShows.Update(slideShow1);
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
			SlideShow slideShow = _appContext.SlideShows.Find(id);

			_appContext.SlideShows.Remove(slideShow);
			_appContext.SaveChanges();
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}
}
