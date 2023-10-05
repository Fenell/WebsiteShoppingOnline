using ShoppingOnline.DAL.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Dtos.ProductItemViewModel;
public class GetProductItem
{
	public Guid ProductId { get; set; }
	public Guid ColorId { get; set; }
	public Guid SizeId { get; set; }
	public int Quantity { get; set; }
	public string Status { get; set; }
	public DateTime CreatedAt { get; set; }
	public string? CreatedBy { get; set; }
	public DateTime UpdateAt { get; set; }
	public string? UpdateBy { get; set; }
	public bool IsDeleted { get; set; }
}
