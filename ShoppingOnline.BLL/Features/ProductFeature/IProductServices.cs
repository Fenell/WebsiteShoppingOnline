using ShoppingOnline.BLL.DataTransferObjects.ProductDTO;

namespace ShoppingOnline.BLL.Features.ProductFeature;
public interface IProductServices
{
	Task<IEnumerable<GetProducts>> GetAllProducts();
	Task<Guid> CreateProduct(CreateProduct create);
	Task<bool> UpdateProduct(UpdateProduct update);
	Task<bool> DeleteProduct(DeleteProduct deleteProduct);
	Task<bool> DeleteHardProduct(DeleteProduct deleteProduct);
	Task<GetProducts> GetProductById(Guid productId);
}
