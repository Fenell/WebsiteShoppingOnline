namespace ShoppingOnline.Admin.Models.ProductItem;

public class ProductItemVM
{
	public Guid Id { get; set; }
	public Guid ProductId { get; set; }
	public string ProductName { get; set; }
	public Guid ColorId { get; set; }
	public Guid SizeId { get; set; }
	public string ColorName { get; set; }
	public string SizeName { get; set; }
	public int Quantity { get; set; }
	public string Status { get; set; }
}