using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Dtos.OrderViewModel;
public class UpdateOrder
{
	public Guid Id { get; set; }
	public string CustomerName { get; set; } = null!;
	public string Address { get; set; } = null!;
	public string PhoneNumber { get; set; } = null!;
	public string? Note { get; set; }
	public string OrderStatus { get; set; }
	public string? PaymentMethod { get; set; } = null!;
	public DateTime UpdateAt { get; set; } = DateTime.Now;
}
