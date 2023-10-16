namespace ShoppingOnline.Admin.ViewModels.Order;

public class OrderGetDtos
{
	public Guid Id { get; set; }
	public string CustomerName { get; set; } = null!;
	public string Address { get; set; } = null!;
	public string PhoneNumber { get; set; } = null!;
	public string Note { get; set; }
	public string OrderStatus { get; set; }
	public decimal Total { get; set; }
}
