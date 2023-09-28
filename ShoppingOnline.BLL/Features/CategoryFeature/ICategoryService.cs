using ShoppingOnline.BLL.DataTransferObjects.CategoryDTO;
using ShoppingOnline.BLL.DataTransferObjects.CategoryDTO.Request;

namespace ShoppingOnline.BLL.Features.CategoryFeature;

public interface ICategoryService
{
	Task<List<CategoryViewModel>> GetAll();
	Task<CategoryViewModel> GetById(Guid id);
	Task<Guid> CreateCategory(CategoryCreateRequest request);
	Task<bool> UpdateCategory(CategoryUpdateRequest request);
	Task<bool> DeleteCategory(Guid id);
}