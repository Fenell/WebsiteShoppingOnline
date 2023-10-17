namespace ShoppingOnline.Admin.ViewModels.ProductItems;

public class ProductItemsGetDtos
{
	public Guid Id { get; set; }
	public Guid ProductId { get; set; }
	public Guid ColorId { get; set; }
	public Guid SizeId { get; set; }
	public int Quantity { get; set; }
}
