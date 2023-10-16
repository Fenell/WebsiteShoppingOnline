using System.ComponentModel.DataAnnotations;

namespace ShoppingOnline.Admin.ViewModels.Models;

public class ColorsVM
{

	public Guid Id { get; set; }
	[Required(ErrorMessage ="Tên không thể bỏ trống!")]
	public string Name { get; set; } = null!;
	public string Status { get; set; }
	public string? CreatedBy { get; set; }
}
