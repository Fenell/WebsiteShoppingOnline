namespace ShoppingOnline.BLL.DataTransferObjects.ProductItemDTO;
public class UpdateProductItem
{
	public Guid Id { get; set; }
	public int Quantity { get; set; }
	public DateTime UpdateAt { get; set; } = DateTime.Now;
}
