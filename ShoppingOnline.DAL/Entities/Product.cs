using ShoppingOnline.DAL.Constants;
using ShoppingOnline.DAL.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingOnline.DAL.Entities
{
	public class Product : BaseEntity
	{
		public Guid CategoryId { get; set; }
		public Guid BrandId { get; set; }
		public string Name { get; set; } = null!;
		public string? SeoTitle { get; set; }
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
		public string? Description { get; set; }
		public string? DefaultImage { get; set; }
		public string Status { get; set; } = EntityStatus.Active;
		public virtual Brand? Brand { get; set; }
		public virtual Category? Category { get; set; }
		public virtual IEnumerable<Ratiting>? Ratitings { get; set; }
		public virtual IEnumerable<ProductItem>? ProductItems { get; set; }
	}
}
