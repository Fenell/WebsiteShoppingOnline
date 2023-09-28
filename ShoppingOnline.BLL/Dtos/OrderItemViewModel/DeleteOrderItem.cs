using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Dtos.OrderItemViewModel;
public class DeleteOrderItem
{
	public Guid Id { get; set; }
	public bool IsDeleted { get; set; }
}
