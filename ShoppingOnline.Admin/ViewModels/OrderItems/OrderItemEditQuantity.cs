namespace ShoppingOnline.Admin.ViewModels.OrderItems;

public class OrderItemEditQuantity
{
	public Guid Id { get; set; }
	public Guid ProductItemId { get; set; }
	public Guid ColorId { get; set; }
	public Guid SizeId { get; set; }
	public int Quantity { get; set; }
}
