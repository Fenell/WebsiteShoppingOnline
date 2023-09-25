using ShoppingOnline.DAL.Constants;
using ShoppingOnline.DAL.Entities.Common;

namespace ShoppingOnline.DAL.Entities;

public class Category : BaseEntity
{
	public string Name { get; set; } = null!;
	public string? SeoTitle { get; set; }
	public string Status { get; set; } = EntityStatus.Active;

	public virtual IEnumerable<Product>? Products { get; set; }
}