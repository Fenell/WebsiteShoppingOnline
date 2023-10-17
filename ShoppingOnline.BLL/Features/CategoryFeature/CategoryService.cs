using AutoMapper;
using ShoppingOnline.BLL.DataTransferObjects.CategoryDTO;
using ShoppingOnline.BLL.DataTransferObjects.CategoryDTO.Request;
using ShoppingOnline.BLL.Exceptions;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Identity;
using ShoppingOnline.DAL.Repositories.Interface;

namespace ShoppingOnline.BLL.Features.CategoryFeature;

public class CategoryService : ICategoryService
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly IMapper _mapper;
	private readonly IUserService _userService;

	public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IUserService userService)
	{
		_categoryRepository = categoryRepository;
		_mapper = mapper;
		_userService = userService;
	}

	public async Task<List<CategoryViewModel>> GetAll()
	{
		var lstCategories = await _categoryRepository.GetAllAsync();
		var lstCategoriesVm = _mapper.Map<List<CategoryViewModel>>(lstCategories);

		foreach (var item in lstCategoriesVm)
		{
			item.CreatedUserName = await _userService.GetUserNameAsync(item.CreatedBy);
			item.UpdatedUserName = await _userService.GetUserNameAsync(item.UpdateBy);
		}

		return lstCategoriesVm;
	}

	public async Task<CategoryViewModel> GetById(Guid id)
	{
		var category = await _categoryRepository.GetByIdAsync(id);

		if (category == null)
			throw new NotFoundException(nameof(Category), id);

		var categoyVm = _mapper.Map<CategoryViewModel>(category);
		categoyVm.CreatedUserName = await _userService.GetUserNameAsync(categoyVm.CreatedBy);
		categoyVm.UpdatedUserName = await _userService.GetUserNameAsync(categoyVm.UpdateBy);

		return categoyVm;
	}

	public async Task<Guid> CreateCategory(CategoryCreateRequest request)
	{
		var categoryCreate = _mapper.Map<Category>(request);
		categoryCreate.CreatedAt = DateTime.Now;
		var result = await _categoryRepository.CreateAsync(categoryCreate);

		return result;
	}



	public async Task<bool> DeleteCategory(Guid id)
	{

		var rs = await _categoryRepository.GetByIdAsync(id);

		if (rs != null)
		{
			await _categoryRepository.DeleteAsync(rs);
			return true;
		}
		else
		{
			return false; ;
		}
	}

	public async Task<bool> UpdateCategory(Guid id, CategoryUpdateRequest request)
	{
		if (id == request.Id)
		{
			var categoryInDb = await _categoryRepository.GetByIdAsync(id);
			_mapper.Map(request, categoryInDb);
			await _categoryRepository.UpdateAsync(categoryInDb);
			return true;
		}
		else
		{
			return false;
		}
	}
}