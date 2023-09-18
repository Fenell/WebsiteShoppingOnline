using ShoppingOnline.DAL.Common;
using ShoppingOnline.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Entities;
public class Promotion : BaseDomainEntity
{
	public string Code { get; set; }
	public int DiscountPercent { get; set; }
	public PromotionStatus PromotionStatus { get; set; }
	public virtual IEnumerable<Order> Orders { get; set; }
}
