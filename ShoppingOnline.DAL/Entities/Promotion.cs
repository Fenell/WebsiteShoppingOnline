using ShoppingOnline.DAL.Constants;
using ShoppingOnline.DAL.Entities.Common;

namespace ShoppingOnline.DAL.Entities;
public class Promotion : BaseEntity
{
	public string Code { get; set; } = null!;
	public int DiscountPercent { get; set; }
	public string PromotionStatus { get; set; } = EntityStatus.Active;
	
	public virtual IEnumerable<Order>? Orders { get; set; }
}
