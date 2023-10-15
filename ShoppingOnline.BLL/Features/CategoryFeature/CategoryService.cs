using AutoMapper;
using ShoppingOnline.BLL.DataTransferObjects.BrandItemDTO;
using ShoppingOnline.BLL.DataTransferObjects.CategoryDTO;
using ShoppingOnline.BLL.DataTransferObjects.CategoryDTO.Request;
using ShoppingOnline.BLL.Exceptions;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Implement;
using ShoppingOnline.DAL.Repositories.Interface;

namespace ShoppingOnline.BLL.Features.CategoryFeature;

public class CategoryService:ICategoryService
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly IMapper _mapper;

	public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
	{
		_categoryRepository = categoryRepository;
		_mapper = mapper;
	}

	public async Task<List<CategoryViewModel>> GetAll()
	{
		var lstCategories = await _categoryRepository.GetAllAsync();

		return _mapper.Map<List<CategoryViewModel>>(lstCategories);
	}

	public async Task<CategoryViewModel> GetById(Guid id)
	{
		var category = await _categoryRepository.GetByIdAsync(id);

		if (category == null)
			throw new NotFoundException(nameof(Category), id);

		return _mapper.Map<CategoryViewModel>(category);
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
			var mapRs =  _mapper.Map<Category>(request);
			await _categoryRepository.UpdateAsync(mapRs);
			return true;
		}
		else
		{
			return false;
		}
	}
}