using ShoppingOnline.DAL.Constants;
using ShoppingOnline.DAL.Entities.Common;

namespace ShoppingOnline.DAL.Entities;
public class ProductImage : BaseEntity
{
	public Guid ProducItemtId { get; set; }
	public string? ImageUrl { get; set; }
	public int Position { get; set; }
	public string Status { get; set; } = EntityStatus.Active;
	public virtual ProductItem? ProductItem { get; set; }


}
