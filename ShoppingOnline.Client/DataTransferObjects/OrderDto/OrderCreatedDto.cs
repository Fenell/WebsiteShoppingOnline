using System.ComponentModel.DataAnnotations;

namespace ShoppingOnline.Client.DataTransferObjects.OrderDto;

public class OrderCreatedDto
{
	public Guid PromotionId { get; set; }
	[Required(ErrorMessage = "Không được bỏ trống")]
	public string CustomerName { get; set; } = null!;
	public string Address { get; set; } = null!;
	public string PhoneNumber { get; set; } = null!;
	public string? Note { get; set; }
	public string PaymentMethod { get; set; }
	public decimal Total { get; set; }

	public List<OrderItemDto> OrderItems { get; set; }

}
