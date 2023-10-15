using Microsoft.AspNetCore.Http;

namespace ShoppingOnline.BLL.DataTransferObjects.ProductImageDTO;

public class ProductImageCreateRequest
{
	public Guid ProductItemId  { get; set; }
	public List<IFormFile> FileUpload  {get; set; }
}