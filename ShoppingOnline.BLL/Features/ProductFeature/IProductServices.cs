using ShoppingOnline.BLL.DataTransferObjects.ProductDTO;
using ShoppingOnline.BLL.DataTransferObjects.ProductDTO.Requests;

namespace ShoppingOnline.BLL.Features.ProductFeature;
public interface IProductServices
{
	Task<IReadOnlyList<GetProducts>> GetAllProducts();
	Task<Guid> CreateProduct(CreateProduct request);
	Task<bool> UpdateProduct(UpdateProduct request);
	Task<bool> SwitchStatusProduct(StatusChangeRequest request);
	Task<bool> DeleteHardProduct(StatusChangeRequest deleteProduct);
	Task<GetProducts> GetProductById(Guid productId);
}
