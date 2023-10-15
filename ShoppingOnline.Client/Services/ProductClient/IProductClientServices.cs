using ShoppingOnline.Client.DataTransferObjects.ProductDto;

namespace ShoppingOnline.Client.Services.ProductClient;

public interface IProductClientServices
{
	Task<IEnumerable<GetProduct>> GetAllProduct();
	Task<GetProduct> GetProductById(Guid id);
}
