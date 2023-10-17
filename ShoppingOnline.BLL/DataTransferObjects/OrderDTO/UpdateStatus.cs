using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.DataTransferObjects.OrderDTO;
public class UpdateStatus
{
	public Guid Id { get; set; }
	public string OrderStatus { get; set; }

	public Guid IdProductItems { get; set; }
	public int Quantity { get; set; }
}
