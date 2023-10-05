using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Dtos.BrandItemViewModel;
public class GetBrand
{
	public Guid Id { get; set; }
	public string Name { get; set; } = null!;
	public string? SeoTitle { get; set; }
	public string Status { get; set; }
}
