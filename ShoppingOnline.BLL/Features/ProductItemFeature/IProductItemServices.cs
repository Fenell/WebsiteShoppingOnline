using ShoppingOnline.BLL.DataTransferObjects.ProductItemDTO;
using ShoppingOnline.BLL.DataTransferObjects.ProductItemDTO.Requests;

namespace ShoppingOnline.BLL.Features.ProductItemFeature;

public interface IProductItemServices
{
	Task<List<GetProductItem>> GetProductItems();
	Task<List<GetProductItem>> GetProductItemWithProductId(Guid productId);
	Task<GetProductItem?> GetProductItemById(Guid id);
	Task<GetProductItem> GetProductItemChienById(Guid id);
	Task<bool> CreateListProductItem(Guid productId, List<ProductItemCreateRequest> requests);
	Task<bool> UpdateProductItem(UpdateProductItem updateProductItem);
	Task<bool> DeleteProductItem(DeleteProductItem deleteProductItem);
	Task<bool> DeleteHardProductItem(DeleteProductItem deletedHardProductItem);
}