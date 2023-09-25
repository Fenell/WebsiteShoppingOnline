using ShoppingOnline.DAL.Constants;
using ShoppingOnline.DAL.Entities.Common;

namespace ShoppingOnline.DAL.Entities;
public class Color : BaseEntity
{
	public string Name { get; set; } = null!;
	public string Status { get; set; } = EntityStatus.Active;
	
	public virtual IEnumerable<ProductItem>? ProductItems { get; set; }
}
