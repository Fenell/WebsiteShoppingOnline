using ShoppingOnline.Admin.Models.Product;

namespace ShoppingOnline.Admin.Services.Interface;

public interface IProductService
{
	Task<List<ProductVM>> GetAllProduct();
	Task<ProductVM> GetProduct(Guid id);
	Task<bool> CreateProduct(ProductCreateRequest request);
	Task<bool> UpdateProduct(ProductUpdateRequest request);
	Task<bool> ChangeStatus(Guid id);



	Task<List<CategoryVM>> GetAllCategoy();
	Task<List<BrandVM>> GetAllBrand();


}