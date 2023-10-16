using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.DataTransferObjects.BrandItemDTO;
public class DeleteBrand
{
	public Guid Id { get; set; }
	public string Name { get; set; } = null!;
	public string Status { get; set; }
}
