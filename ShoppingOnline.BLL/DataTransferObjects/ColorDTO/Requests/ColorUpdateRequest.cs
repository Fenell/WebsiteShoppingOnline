namespace ShoppingOnline.BLL.DataTransferObjects.ColorDTO.Requests;
public class ColorUpdateRequest
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string? UpdateBy { get; set; }
}
