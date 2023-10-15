using ShoppingOnline.Client.DataTransferObjects.ProductItemDto;

namespace ShoppingOnline.Client.Services.ProductItemClient;

public interface IProductItemClientServices
{
	Task<IEnumerable<ProductItemGet>> GetProductsAsync();
	Task<bool> UpdateProductItem(UpdateQuantity updateQuantity);
}
