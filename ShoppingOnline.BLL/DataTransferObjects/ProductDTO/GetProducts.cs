namespace ShoppingOnline.BLL.DataTransferObjects.ProductDTO;
public class GetProducts
{
	public Guid Id { get; set; }
	public Guid CategoryId { get; set; }
	public Guid BrandId { get; set; }
	public string Name { get; set; } = null!;
	public string? SeoTitle { get; set; }
	public decimal Price { get; set; }
	public decimal Discount { get; set; }
	public string? Description { get; set; }
	public string? DefaultImage { get; set; }
	public string Status { get; set; }
	public DateTime CreatedAt { get; set; }
	public string? CreatedBy { get; set; }
	public DateTime UpdateAt { get; set; }
	public string? UpdateBy { get; set; }
	public bool IsDeleted { get; set; }
}
