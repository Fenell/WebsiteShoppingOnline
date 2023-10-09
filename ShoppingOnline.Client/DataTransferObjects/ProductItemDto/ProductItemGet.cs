namespace ShoppingOnline.Client.DataTransferObjects.ProductItemDto;

public class ProductItemGet
{
	public Guid Id { get; set; }
	public Guid ProductId { get; set; }
	public Guid ColorId { get; set; }
	public Guid SizeId { get; set; }
	public int Quantity { get; set; }
	public string Status { get; set; }
}
