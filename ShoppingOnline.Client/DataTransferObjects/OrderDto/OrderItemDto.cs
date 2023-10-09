namespace ShoppingOnline.Client.DataTransferObjects.OrderDto;

public class OrderItemDto
{
	public Guid ProductItemId { get; set; }
	public int Quantity { get; set; }
	public decimal Price { get; set; }
}
