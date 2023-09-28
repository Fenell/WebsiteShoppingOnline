using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.DataTransferObjects.Color.Requests;
public class ColorUpdateRequest
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string? UpdateBy { get; set; }
}
