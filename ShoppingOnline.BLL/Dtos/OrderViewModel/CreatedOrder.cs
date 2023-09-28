using ShoppingOnline.BLL.Dtos.OrderItemViewModel;
using ShoppingOnline.DAL.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Dtos.OrderViewModel;
public class CreatedOrder
{
	public Guid PromotionId { get; set; }
	public string CustomerName { get; set; } = null!;
	public string Address { get; set; } = null!;
	public string PhoneNumber { get; set; } = null!;
	public string? Note { get; set; }
	public string OrderStatus { get; set; }
	public string? PaymentMethod { get; set; } = null!;
	public decimal Total { get; set; }

	public Guid ProductItemId { get; set; }
	public int Quantity { get; set; }
	public decimal Price { get; set; }
}
