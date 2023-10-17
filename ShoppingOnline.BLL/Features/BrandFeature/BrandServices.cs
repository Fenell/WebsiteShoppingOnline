using AutoMapper;
using ShoppingOnline.BLL.DataTransferObjects.BrandItemDTO;
using ShoppingOnline.BLL.Exceptions;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Identity;
using ShoppingOnline.DAL.Repositories.Implement;
using ShoppingOnline.DAL.Repositories.Interface;

namespace ShoppingOnline.BLL.Features.BrandFeature;
public class BrandServices : IBrandServices
{
	private readonly IBrandRepository _brandRepository;
	private readonly IMapper _mapper;
	private readonly IUserService _userService;

	public BrandServices(IBrandRepository brandRepository, IMapper mapper, IUserService userService)
	{
		_brandRepository = brandRepository;
		_mapper = mapper;
		_userService = userService;
	}
	public async Task<Guid> CreatedBrand(CreatedBrand brand)
	{
		var requestMap = _mapper.Map<CreatedBrand, Brand>(brand);
		await _brandRepository.CreateAsync(requestMap);
		return requestMap.Id;
	}

	public async Task<bool> DeleteBrand(Guid id)
	{
		var br = await _brandRepository.GetByIdAsync(id);

		if (br != null)
		{
			await _brandRepository.DeleteAsync(br);
			return true;
		}
		else
		{
			throw new NotFoundException(nameof(Brand), id);
			
		}
	}

	public async Task<List<GetBrand>> GetAllBrands()
	{
		var request = await _brandRepository.GetAllAsync();
		var requestMap = _mapper.Map<List<GetBrand>>(request);

		foreach (var item in requestMap)
		{
			item.CreatedUserName = await _userService.GetUserNameAsync(item.CreatedBy);
			item.UpdatedUserName = await _userService.GetUserNameAsync(item.UpdateBy);
		}

		return requestMap;
	}

	public async Task<GetBrand> GetBrandById(Guid id)
	{
		var request = await _brandRepository.GetByIdAsync(id);

		if (request == null)
			throw new NotFoundException(nameof(request), id);

		var requestMap = _mapper.Map<GetBrand>(request);
		requestMap.CreatedUserName = await _userService.GetUserNameAsync(request.CreatedBy);
		requestMap.UpdatedUserName = await _userService.GetUserNameAsync(request.UpdateBy);

		return requestMap;
	}

	public async Task<bool> UpdateBrand(Guid id, UpdateBrand updateBrand)
	{
		if (id == updateBrand.Id)
		{
			var brandInDb = await _brandRepository.GetByIdAsync(id);
			_mapper.Map(updateBrand, brandInDb);
			await _brandRepository.UpdateAsync(brandInDb);
			return true;
		}
		else
		{
			return false;
		}
	}
}
