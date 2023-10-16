using ShoppingOnline.Admin.ViewModels.ViewModelClient;

namespace ShoppingOnline.Admin.Services.Interface;

public interface ICategoryClientService
{
	Task<List<CategoryVM>> GetAll();
	Task<CategoryVM> GetAllById(Guid id);
	Task<bool> CreateCategory(CategoryVM ct);
	Task<bool> UpdateCategory( CategoryVM ct);
	Task<bool> DeleteCategory(Guid id);


}
