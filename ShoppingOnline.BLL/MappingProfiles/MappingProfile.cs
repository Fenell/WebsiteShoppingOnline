using AutoMapper;
using ShoppingOnline.BLL.Dtos.ProductItemViewModel;
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
		CreateMap<CreateProduct, Product>();
		CreateMap<UpdateProduct, Product>();
		#endregion
		#region ProductItems
		CreateMap<ProductItem, GetProductItem>();
		CreateMap<UpdateProductItem, ProductItem>();
		#endregion
	}
}
