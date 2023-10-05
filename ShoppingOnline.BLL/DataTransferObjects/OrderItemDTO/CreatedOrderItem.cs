namespace ShoppingOnline.BLL.DataTransferObjects.OrderItemDTO;
public class CreatedOrderItem
{
	public Guid OrderId { get; set; }
	public Guid ProductItemId { get; set; }
	public int Quantity { get; set; }
	public decimal Price { get; set; }
}
