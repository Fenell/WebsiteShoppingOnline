using ShoppingOnline.Admin.ViewModels.Product;

namespace ShoppingOnline.Admin.Services.Interface;

public interface IProductServices
{
	Task<ProductGetDtos> GetProductById(Guid id);
}
