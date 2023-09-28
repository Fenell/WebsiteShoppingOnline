using ShoppingOnline.BLL.Dtos.OrderViewModel;
using ShoppingOnline.BLL.Dtos.ProductItemViewModel;
using ShoppingOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Dtos.OrderItemViewModel;
public class UpdateOrderItem
{
	public Guid Id { get; set; }
	public int Quantity { get; set; }
}
