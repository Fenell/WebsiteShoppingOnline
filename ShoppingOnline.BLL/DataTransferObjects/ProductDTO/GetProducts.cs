using ShoppingOnline.BLL.DataTransferObjects.ProductItemDTO;

namespace ShoppingOnline.BLL.DataTransferObjects.ProductDTO;
public class GetProducts
{
	public Guid Id { get; set; }
	public Guid CategoryId { get; set; }
	public Guid BrandId { get; set; }
	public string CategoryName { get; set; }
	public string BrandName { get; set; }
	public string Name { get; set; } = null!;
	public string? SeoTitle { get; set; }
	public decimal Price { get; set; }
	public string? Description { get; set; }
	public string Status { get; set; }
	public bool IsDeleted { get; set; }

}
