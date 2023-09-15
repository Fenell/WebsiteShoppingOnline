using ShoppingOnline.DAL.Common;
using ShoppingOnline.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Entities;
[Table("Brand")]
public class Brand : BaseDomainEntity
{
	public string Name { get; set; }
	public string SeoTitle { get; set; }
	public Status Status { get; set; }
	public virtual IEnumerable<Product> Products { get; set; }
}
