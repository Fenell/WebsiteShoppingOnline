using ShoppingOnline.DAL.Common;
using ShoppingOnline.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Entities;
public class OrderItem : BaseDomainEntity
{
	public Guid OrderId { get; set; }
	public Guid ProductItemId { get; set; }
	public OrderStatus OrderStatus { get; set; }
	public int Quantity { get; set; }
	public decimal Price { get; set; }
	public virtual Order Order { get; set; }
	public virtual ProductItem ProductItem { get; set; }
}
