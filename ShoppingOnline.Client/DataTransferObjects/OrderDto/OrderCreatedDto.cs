namespace ShoppingOnline.Client.DataTransferObjects.OrderDto;

public class OrderCreatedDto
{
	public Guid PromotionId { get; set; }
	public string CustomerName { get; set; } = null!;
	public string Address { get; set; } = null!;
	public string PhoneNumber { get; set; } = null!;
	public string? Note { get; set; }
	public decimal Total { get; set; }

	public List<OrderItemDto> OrderItems { get; set; }

}
