using ShoppingOnline.DAL.Common;
using ShoppingOnline.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Entities
{
	[Table("Product")]
	public class Product : BaseDomainEntity
	{
		public Guid CategoryId { get; set; }
		public Guid BrandId { get; set; }
		public string Name { get; set; }
		public string SeoTitle { get; set; }
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
		public string Description { get; set; }
		public string DefaultImage { get; set; }
		public Status Status { get; set; }
		public virtual Brand Brand { get; set; }
		public virtual Category Category { get; set; }
		public virtual IEnumerable<Ratiting> Ratitings { get; set; }
		public virtual IEnumerable<ProductItem> ProductItems { get; set; }
	}
}
