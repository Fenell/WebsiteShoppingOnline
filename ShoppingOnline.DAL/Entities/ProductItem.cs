using ShoppingOnline.DAL.Constants;
using ShoppingOnline.DAL.Entities.Common;

namespace ShoppingOnline.DAL.Entities;
public class ProductItem : BaseEntity
{
	public Guid ProductId { get; set; }
	public Guid ColorId { get; set; }
	public Guid SizeId { get; set; }
	public int Quantity { get; set; }
	public string Status { get; set; } = EntityStatus.Active;
	
	public virtual IEnumerable<ProductImage>? ProductImages { get; set; }
	public virtual IEnumerable<OrderItem>? OrderItems { get; set; }
	public virtual Product? Product { get; set; }
	public virtual Color? Color { get; set; }
	public virtual Size? Size { get; set; }
}
