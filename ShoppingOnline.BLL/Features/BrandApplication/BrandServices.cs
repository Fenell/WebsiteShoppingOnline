using AutoMapper;
using ShoppingOnline.BLL.Dtos.BrandItemViewModel;
using ShoppingOnline.BLL.Exceptions;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Features.BrandApplication;
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
		var requestMap = _mapper.Map<CreatedBrand, Brand>(brand);
		await _brandRepository.CreateAsync(requestMap);
		return requestMap.Id;
	}

	public async Task<bool> DeleteBrand(GetBrand brand)
	{
		var request = await _brandRepository.GetByIdAsync(brand.Id);
		if (request == null)
			throw new NotFoundException(nameof(request), brand.Id);
		return await _brandRepository.DeleteBrand(request);
	}

	public async Task<IEnumerable<GetBrand>> GetAllBrands()
	{
		var request = await _brandRepository.GetAllBrands();
		var requestMap = _mapper.Map<IEnumerable<GetBrand>>(request);
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

	public async Task<bool> UpdateBrand(UpdateBrand brand)
	{
		var request = await _brandRepository.GetBrandById(brand.Id);

		if (request == null)
			throw new NotFoundException(nameof(request), brand.Id);

		var requestMap = _mapper.Map<UpdateBrand, Brand>(brand, request);
		return await _brandRepository.UpdateBrand(requestMap);
	}
}
