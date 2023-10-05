using ShoppingOnline.BLL.DataTransferObjects.ProductItemDTO;

namespace ShoppingOnline.BLL.Features.ProductItemFeature;
public interface IProductItemServices
{
	Task<IEnumerable<GetProductItem>> GetProductItems();
	Task<GetProductItem> GetProductItemById(Guid id);
	Task<bool> UpdateProductItem(UpdateProductItem updateProductItem);
	Task<bool> DeleteProductItem(DeleteProductItem deleteProductItem);
	Task<bool> DeleteHardProductItem(DeleteProductItem deletedHardProductItem);
}
