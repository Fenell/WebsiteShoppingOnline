using AutoMapper;
using ShoppingOnline.BLL.Dtos.ProductViewModel;
using ShoppingOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.MappingProfiles;
public class MappingProfile : Profile
{
	public MappingProfile()
	{
		#region ProductMapping
		CreateMap<Product, GetProducts>();
		#endregion
	}
}
