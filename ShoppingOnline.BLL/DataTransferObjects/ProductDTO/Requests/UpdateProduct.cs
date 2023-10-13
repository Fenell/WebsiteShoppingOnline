namespace ShoppingOnline.BLL.DataTransferObjects.ProductDTO.Requests;
public class UpdateProduct
{
	public Guid Id { get; set; }
	public Guid CategoryId { get; set; }
	public Guid BrandId { get; set; }
	public string Name { get; set; } = null!;
	public decimal Price { get; set; }
	public string? Description { get; set; }
	public string? DefaultImage { get; set; }
	public DateTime UpdateAt { get; set; }
}
