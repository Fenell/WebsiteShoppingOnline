namespace ShoppingOnline.BLL.DataTransferObjects.BrandItemDTO;
public class GetBrand
{
	public Guid Id { get; set; }
	public string Name { get; set; } = null!;
	public string? SeoTitle { get; set; }
	public string Status { get; set; }
}
