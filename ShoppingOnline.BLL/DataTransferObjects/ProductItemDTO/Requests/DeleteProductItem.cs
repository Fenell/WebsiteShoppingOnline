namespace ShoppingOnline.BLL.DataTransferObjects.ProductItemDTO.Requests;
public class DeleteProductItem
{
	public Guid Id { get; set; }
	public bool IsDeleted { get; set; }
}
