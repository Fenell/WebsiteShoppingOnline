using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Dtos.ProductItemViewModel;
public class UpdateProductItem
{
	public Guid Id { get; set; }
	public int Quantity { get; set; }
	public string Status { get; set; }
	public DateTime UpdateAt { get; set; } = DateTime.Now;
	public bool IsDeleted { get; set; }
}
