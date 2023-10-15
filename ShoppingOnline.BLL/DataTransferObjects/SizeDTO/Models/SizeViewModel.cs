using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.DataTransferObjects.SizeDTO.Models;
public class SizeViewModel
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string Status { get; set; }
	public string? CreatedBy { get; set; }
}
