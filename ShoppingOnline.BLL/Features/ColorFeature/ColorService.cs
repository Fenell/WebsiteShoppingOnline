using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.BLL.DataTransferObjects.ColorDTO;
using ShoppingOnline.BLL.DataTransferObjects.ColorDTO.Requests;
using ShoppingOnline.BLL.Exceptions;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Features.ColorFeature;
public class ColorService : IColorService
{
	private readonly IColorRepository _colorRepository;
	private readonly IMapper _mapper;

	public ColorService(IColorRepository colorRepository, IMapper mapper)
	{
		_colorRepository = colorRepository;
		_mapper = mapper;
	}

	public async Task<Guid> CreateColor([FromBody] ColorCreateRequest request)
	{
		var colorCreate = _mapper.Map<Color>(request);
		var result = await _colorRepository.CreateAsync(colorCreate);
		return result;
	}

	public async Task DeleteColor(Guid id)
	{
		var color = await _colorRepository.GetByIdAsync(id);

		if (color != null)
		{
			await _colorRepository.DeleteAsync(color);
		}
		else
		{
			throw new NotFoundException(nameof(Color), id);
		}
	}

	public async Task<List<ColorViewModel>> GetAll()
	{
		var listColor = await _colorRepository.GetAllAsync();

		var listColorDto = _mapper.Map<List<ColorViewModel>>(await listColor.ToListAsync());

		return listColorDto;
	}


	public async Task UpdateColor(Guid id, ColorUpdateRequest request)
	{
		if (id == request.Id)
		{
			var updateColor = _mapper.Map<Color>(request);
			await _colorRepository.UpdateAsync(updateColor);
		}
		else
		{
			throw new NotFoundException(nameof(Color), id);
		}
	}

	public async Task<ColorViewModel> GetById(Guid id)
	{
		var color = await _colorRepository.GetByIdAsync(id);
		if (color == null)
		{
			throw new NotFoundException(nameof(Color), id);
		}
		else
		{
			var colors = _mapper.Map<ColorViewModel>(color);
			return colors;
		}
	}
}
