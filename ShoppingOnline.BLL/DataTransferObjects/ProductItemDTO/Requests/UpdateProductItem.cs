namespace ShoppingOnline.BLL.DataTransferObjects.ProductItemDTO.Requests;
public class UpdateProductItem
{
	public Guid Id { get; set; }
	public int Quantity { get; set; }
	public Guid SizeId { get; set; }
	public Guid ColorId { get; set; }
	public DateTime UpdateAt { get; set; } = DateTime.Now;
	public bool IsDeleted { get; set; }
}
