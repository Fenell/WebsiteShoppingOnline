namespace ShoppingOnline.BLL.DataTransferObjects.ProductImageDTO;

public class ProductImageVM
{
	public Guid Id { get; set; }
	public Guid ProducItemtId { get; set; }
	public string? ImageUrl { get; set; }
	public int Position { get; set; }
}