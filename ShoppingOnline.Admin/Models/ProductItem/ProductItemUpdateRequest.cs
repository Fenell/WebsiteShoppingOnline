namespace ShoppingOnline.Admin.Models.ProductItem;

public class ProductItemUpdateRequest
{
	public Guid Id { get; set; }
	public Guid ProductId { get; set; }
	public Guid ColorId { get; set; }
	public Guid SizeId { get; set; }
	public int Quantity { get; set; }
}