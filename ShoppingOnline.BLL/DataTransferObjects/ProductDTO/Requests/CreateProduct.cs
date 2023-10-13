namespace ShoppingOnline.BLL.DataTransferObjects.ProductDTO.Requests;
public class CreateProduct
{
	public Guid CategoryId { get; set; }
	public Guid BrandId { get; set; }
	public string Name { get; set; } = null!;
	public string? SeoTitle { get; set; }
	public decimal Price { get; set; }
	public string? Description { get; set; }
	public string? DefaultImage { get; set; }
}
