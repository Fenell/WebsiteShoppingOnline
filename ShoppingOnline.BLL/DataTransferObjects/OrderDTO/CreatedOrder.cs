using ShoppingOnline.DAL.Entities;

namespace ShoppingOnline.BLL.DataTransferObjects.OrderDTO;
public class CreatedOrder
{
	public Guid PromotionId { get; set; }
	public string CustomerName { get; set; } = null!;
	public string Address { get; set; } = null!;
	public string PhoneNumber { get; set; } = null!;
	public string? Note { get; set; }
	public string? PaymentMethod { get; set; } = null!;
	public decimal Total { get; set; }

	public IEnumerable<OrderItemDto>? OrderItems { get; set; }
}
