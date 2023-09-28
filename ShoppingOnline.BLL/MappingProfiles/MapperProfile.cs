using AutoMapper;
using ShoppingOnline.BLL.DataTransferObjects.Color.Requests;
using ShoppingOnline.BLL.DataTransferObjects.ColorDTO;
using ShoppingOnline.BLL.DataTransferObjects.SizeDTO.Models;
using ShoppingOnline.BLL.DataTransferObjects.SizeDTO.Requests;
using ShoppingOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.MappingProfiles;
public class MapperProfile : Profile
{
	public MapperProfile()
	{
		//ReverseMap giup map 2 chieu
		#region ColorProfile
		    CreateMap<Color, ColorViewModel>().ReverseMap();
 		    CreateMap<Color, ColorUpdateRequest>().ReverseMap();
 		    CreateMap<Color, ColorCreateRequest>().ReverseMap();
		#endregion
		#region SizeProfile
		CreateMap<Size, SizeCreateRequest>().ReverseMap();
		CreateMap<Size, SizeUpdateRequest>().ReverseMap();
		CreateMap<Size, SizeViewModel>().ReverseMap();
		#endregion
	}
}
