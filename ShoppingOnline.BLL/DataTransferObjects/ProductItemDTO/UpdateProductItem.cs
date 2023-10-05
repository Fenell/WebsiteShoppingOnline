namespace ShoppingOnline.BLL.DataTransferObjects.ProductItemDTO;
public class UpdateProductItem
{
	public Guid Id { get; set; }
	public int Quantity { get; set; }
	public string Status { get; set; }
	public DateTime UpdateAt { get; set; } = DateTime.Now;
	public bool IsDeleted { get; set; }
}
