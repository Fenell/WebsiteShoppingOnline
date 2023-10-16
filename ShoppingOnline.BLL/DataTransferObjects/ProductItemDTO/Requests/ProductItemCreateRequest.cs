namespace ShoppingOnline.BLL.DataTransferObjects.ProductItemDTO.Requests;

public class ProductItemCreateRequest
{
	public Guid SizeId { get; set; }
	public Guid ColorId { get; set; }
	public int Quantity { get; set; }
	
}