using ShoppingOnline.DAL.Common;
using ShoppingOnline.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Entities;
public class Color : BaseDomainEntity
{
	public string Name { get; set; }
	public Status Status { get; set; }
	public virtual IEnumerable<ProductItem> ProductItems { get; set; }
}
