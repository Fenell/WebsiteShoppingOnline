using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.DataTransferObjects.SizeDTO.Requests;
public class SizeCreateRequest
{
	public string Name { get; set; }
	public string? CreatedBy { get; set; }
}
