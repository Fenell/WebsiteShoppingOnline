using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Dtos.OrderItemViewModel;
public class CreatedOrderItem
{
	public Guid OrderId { get; set; }
	public Guid ProductItemId { get; set; }
	public int Quantity { get; set; }
	public decimal Price { get; set; }
}
