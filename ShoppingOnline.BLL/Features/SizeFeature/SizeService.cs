using AutoMapper;
using ShoppingOnline.BLL.DataTransferObjects.SizeDTO.Models;
using ShoppingOnline.BLL.DataTransferObjects.SizeDTO.Requests;
using ShoppingOnline.BLL.Exceptions;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Features.SizeFeature;
public class SizeService : ISizeService
{
	private readonly ISizeRepository _sizeRepository;
	private readonly IMapper _mapper;

	public SizeService(ISizeRepository sizeRepository, IMapper mapper)
	{
		_sizeRepository = sizeRepository;
		_mapper = mapper;
	}

	public async Task<Guid> CreateSize(SizeCreateRequest request)
	{
		var sizeCreate = _mapper.Map<Size>(request);
		var size = await _sizeRepository.CreateAsync(sizeCreate);
		return size;
	}

	public async Task DeleteSize(Guid id)
	{
		var size = await _sizeRepository.GetByIdAsync(id);
		if (size != null) 
		{
			await _sizeRepository.DeleteAsync(size);
		}
		else
		{
			throw new NotFoundException(nameof(Size),id);
		}
	}

	public async Task<List<SizeViewModel>> GetAllSize()
	{
		var size = await _sizeRepository.GetAllAsync();
		var listsize = _mapper.Map<List<SizeViewModel>>(size);
		return listsize;
	}

	public async Task<Size> GetByIdSize(Guid id)
	{
		var size = await _sizeRepository.GetByIdAsync(id);
		if (size == null) 
		{
			throw new NotFoundException(nameof(Size),id);
		}
		else
		{
			return size;
		}
	}

	public async Task UpdateSize(Guid id, SizeUpdateRequest request)
	{
		if (id == request.Id)
		{
			var size = _mapper.Map<Size>(request);
			await _sizeRepository.UpdateAsync(size); 
		}
		else { throw new NotFoundException(nameof(Size), id); }
	}
}
