namespace ShoppingOnline.Admin.Models.ProductItem;

public class ProductItemCreateRequest
{
	public Guid ColorId { get; set; }
	public Guid SizeId { get; set; }
	public int Quantity { get; set; }
}