using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.DataTransferObjects.Color.Requests;
public class ColorDeleteRequest
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string? DeleteBy { get; set; }
}
