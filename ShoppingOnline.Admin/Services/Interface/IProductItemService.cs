using ShoppingOnline.Admin.Models.ProductItem;

namespace ShoppingOnline.Admin.Services.Interface;

public interface IProductItemService
{
	Task<List<ProductItemVM>> GetProductItemsWithProductId(Guid productId);
	Task<ProductItemVM> GetProductItemById(Guid id);
	Task<bool> CreateProducItem(Guid productId, List<ProductItemCreateRequest> request);
	Task<bool> UpdateProductItem(ProductItemUpdateRequest request);
	Task<List<ColorVM>> GetAllColor();
	Task<List<SizeVM>> GetAllSize();
}