using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Dtos.OrderViewModel;
public class DeleteOrder
{
	public Guid Id { get; set; }
	public bool IsDeleted { get; set; }
}
