using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.DataTransferObjects.Color.Requests;
public class ColorCreateRequest
{
	[Required(ErrorMessage ="Tên không đúng định dạng!")]
	public string Name { get; set; }

	//Id cua nguoi da them moi
	public string? CreatedBy { get; set; }
}
