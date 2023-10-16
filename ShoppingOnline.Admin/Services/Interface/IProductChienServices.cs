using ShoppingOnline.Admin.ViewModels.Product;

namespace ShoppingOnline.Admin.Services.Interface;

public interface IProductChienServices
{
	Task<ProductGetDtos> GetProductById(Guid id);
}
