namespace ShoppingOnline.Client.DataTransferObjects.CartDto;

public class CartDto
{
	public Guid IdProduct { get; set; }
	public string Name { get; set; }
	public decimal Price { get; set; }
	public string Size { get; set; }
	public string Color { get; set; }
	public int Quantity { get; set; }
	public decimal Total => Price * Quantity;
}
