using ShoppingOnline.DAL.Common;
using ShoppingOnline.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Entities;
public class ProductImage : BaseDomainEntity
{
	public Guid ProducItemtId { get; set; }
	public string ImageUrl { get; set; }
	public string Position { get; set; }
	public Status Status { get; set; }
	public virtual ProductItem ProductItem { get; set; }
}
