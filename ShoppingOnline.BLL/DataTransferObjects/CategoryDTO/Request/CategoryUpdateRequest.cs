namespace ShoppingOnline.BLL.DataTransferObjects.CategoryDTO.Request;

public class CategoryUpdateRequest
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string SeoTitle { get; set; }
	
}