using ShoppingOnline.DAL.Constants;
using ShoppingOnline.DAL.Entities.Common;

namespace ShoppingOnline.DAL.Entities;

public class Order : BaseEntity
{
	public Guid PromotionId { get; set; }
	public string CustomerName { get; set; } = null!;
	public string Address { get; set; } = null!;
	public string PhoneNumber { get; set; } = null!;
	public string? Note { get; set; }
	public string OrderStatus { get; set; } = EntityStatus.Active;
	public string PaymentMethod { get; set; } = null!;
	public decimal Total { get; set; }

	public virtual IEnumerable<OrderItem>? OrderItems { get; set; }
	public virtual Promotion? Promotion { get; set; }
}