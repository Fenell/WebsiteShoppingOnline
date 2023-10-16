using ShoppingOnline.DAL.Constants;
using ShoppingOnline.DAL.Entities.Common;

namespace ShoppingOnline.DAL.Entities;

public class Brand : BaseEntity
{
	public string Name { get; set; } = null!;

	public string Status { get; set; } = EntityStatus.Active;
	public string? CreatedBy { get; set; }
	public virtual IEnumerable<Product>? Products { get; set; }


}