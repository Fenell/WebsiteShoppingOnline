using ShoppingOnline.Admin.ViewModels.ProductItems;

namespace ShoppingOnline.Admin.Services.Interface;

public interface IProductItemsChienServices
{
	Task<ProductItemsGetDtos> GetProductItemById(Guid id);
	Task<List<ProductItemsGetDtos>> GetProductItems();
}
