using ShoppingOnline.DAL.Common;
using ShoppingOnline.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Entities;
public class ProductItem : BaseDomainEntity
{
	public Guid ProductId { get; set; }
	public Guid ColorId { get; set; }
	public Guid SizeId { get; set; }
	public int Quantity { get; set; }
	public Status Status { get; set; }
	public virtual IEnumerable<ProductImage> ProductImages { get; set; }
	public virtual IEnumerable<OrderItem> OrderItems { get; set; }
	public virtual Product Product { get; set; }
	public virtual Color Color { get; set; }
	public virtual Size Size { get; set; }
}
