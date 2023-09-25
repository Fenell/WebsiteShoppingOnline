using ShoppingOnline.DAL.Constants;
using ShoppingOnline.DAL.Entities.Common;

namespace ShoppingOnline.DAL.Entities;
public class OrderItem : BaseEntity
{
	public Guid OrderId { get; set; }
	public Guid ProductItemId { get; set; }
	public string OrderStatus { get; set; } = EntityStatus.Active;
	public int Quantity { get; set; }
	public decimal Price { get; set; }
	public virtual Order? Order { get; set; }
	public virtual ProductItem? ProductItem { get; set; }
}
