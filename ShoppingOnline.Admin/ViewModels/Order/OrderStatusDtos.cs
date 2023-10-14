namespace ShoppingOnline.Admin.ViewModels.Order;

public class OrderStatusDtos
{
	public Guid Id { get; set; }
	public string OrderStatus { get; set; }

	public Guid IdProductItems { get; set; }
	public int Quantity { get; set; }
}
