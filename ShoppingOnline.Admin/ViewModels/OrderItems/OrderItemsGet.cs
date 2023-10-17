namespace ShoppingOnline.Admin.ViewModels.OrderItems;

public class OrderItemsGet
{
	public Guid Id { get; set; }
	public Guid OrderId { get; set; }
	public Guid ProductItemId { get; set; }
	public int Quantity { get; set; }
}
