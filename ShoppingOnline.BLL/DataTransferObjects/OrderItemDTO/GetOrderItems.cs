namespace ShoppingOnline.BLL.DataTransferObjects.OrderItemDTO;
public class GetOrderItems
{
	public Guid Id { get; set; }
	public Guid OrderId { get; set; }
	public Guid ProductItemId { get; set; }
	public string OrderStatus { get; set; }
	public int Quantity { get; set; }
	public decimal Price { get; set; }
	public DateTime CreatedAt { get; set; }
	public string? CreatedBy { get; set; }
	public DateTime UpdateAt { get; set; }
	public string? UpdateBy { get; set; }
	public bool IsDeleted { get; set; }
}
