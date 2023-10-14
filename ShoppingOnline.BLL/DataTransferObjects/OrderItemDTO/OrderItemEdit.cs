using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.DataTransferObjects.OrderItemDTO;
public class OrderItemEdit
{
	public Guid Id { get; set; }
	public Guid ProductItemId { get; set; }

	public Guid ColorId { get; set; }
	public Guid SizeId { get; set; }
	public int Quantity { get; set; }
}
