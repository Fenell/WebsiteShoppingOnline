using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.DataTransferObjects.CategoryDTO.Request;
public class CategoryDeleteRequest
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string DeletedBy { get; set; }
}
