using ShoppingOnline.Admin.ViewModels.ProductItems;

namespace ShoppingOnline.Admin.Services.Interface;

public interface IProductItemsServices
{
	Task<ProductItemsGetDtos> GetProductItemById(Guid id);
	Task<List<ProductItemsGetDtos>> GetProductItems();
}
