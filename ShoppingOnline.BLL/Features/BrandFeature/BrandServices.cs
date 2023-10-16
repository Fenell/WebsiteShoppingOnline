using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.BLL.DataTransferObjects.BrandItemDTO;
using ShoppingOnline.BLL.DataTransferObjects.ColorDTO.Requests;
using ShoppingOnline.BLL.Exceptions;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Implement;
using ShoppingOnline.DAL.Repositories.Interface;

namespace ShoppingOnline.BLL.Features.BrandFeature;
public class BrandServices : IBrandServices
{
	private readonly IBrandRepository _brandRepository;
	private readonly IMapper _mapper;
	public BrandServices(IBrandRepository brandRepository, IMapper mapper)
	{
		_brandRepository = brandRepository;
		_mapper = mapper;
	}


	public async Task<Guid> CreatedBrand(CreatedBrand brand)
	{
		var brandCreate = _mapper.Map<Brand>(brand);
		var result = await _brandRepository.CreateAsync(brandCreate);
		return result;
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
		var request = await _brandRepository.GetAllBrands();
		var requestMap = _mapper.Map<List<GetBrand>>(request);
		return requestMap;
	}

	public async Task<GetBrand> GetBrandById(Guid id)
	{
		var request = await _brandRepository.GetByIdAsync(id);

		if (request == null)
			throw new NotFoundException(nameof(request), id);

		var requestMap = _mapper.Map<GetBrand>(request);
		return requestMap;
	}


	public async Task<bool> UpdateBrand(Guid id, UpdateBrand updateBrand)
	{
		if (id == updateBrand.Id)
		{
			var mapRs = _mapper.Map<Brand>(updateBrand);
			await _brandRepository.UpdateAsync(mapRs);
			return true;
		}
		else
		{
			return false;
		}
	}
}
