namespace ShoppingOnline.BLL.DataTransferObjects.ColorDTO.Requests;
public class ColorDeleteRequest
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string? DeleteBy { get; set; }
}
