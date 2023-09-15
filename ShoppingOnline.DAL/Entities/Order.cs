using ShoppingOnline.DAL.Common;
using ShoppingOnline.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Entities;
public class Order : BaseDomainEntity
{
	public Guid PromotionId { get; set; }
	public decimal Total { get; set; }
	public string CustomerName { get; set; }
	public string Address { get; set; }
	public string PhoneNumber { get; set; }
	public string Note { get; set; }
	public OrderStatus OrderStatus { get; set; }
	public virtual IEnumerable<OrderItem> OrderItems { get; set; }
	public virtual Payment Payment { get; set; }
	public virtual Promotion Promotion { get; set; }
}
