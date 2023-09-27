using ShoppingOnline.DAL.Entities.Common;

namespace ShoppingOnline.DAL.Entities;

public class SlideShow : BaseEntity
{
	public string ImageUrl { get; set; } = null!;
	public string? LinkDetail { get; set; }
	public int Position { get; set; }
}