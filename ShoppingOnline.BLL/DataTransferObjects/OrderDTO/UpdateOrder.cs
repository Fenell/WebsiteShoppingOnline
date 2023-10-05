namespace ShoppingOnline.BLL.DataTransferObjects.OrderDTO;
public class UpdateOrder
{
	public Guid Id { get; set; }
	public string CustomerName { get; set; } = null!;
	public string Address { get; set; } = null!;
	public string PhoneNumber { get; set; } = null!;
	public string? Note { get; set; }
	public string OrderStatus { get; set; }
	public string? PaymentMethod { get; set; } = null!;
	public DateTime UpdateAt { get; set; } = DateTime.Now;
}
