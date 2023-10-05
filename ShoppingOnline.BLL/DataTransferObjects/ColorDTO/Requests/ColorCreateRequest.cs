using System.ComponentModel.DataAnnotations;

namespace ShoppingOnline.BLL.DataTransferObjects.ColorDTO.Requests;
public class ColorCreateRequest
{
	[Required(ErrorMessage ="Tên không đúng định dạng!")]
	public string Name { get; set; }

	//Id cua nguoi da them moi
	public string? CreatedBy { get; set; }
}
