using AutoMapper;
using ShoppingOnline.BLL.DataTransferObjects.BrandItemDTO;
using ShoppingOnline.BLL.DataTransferObjects.CategoryDTO;
using ShoppingOnline.BLL.DataTransferObjects.CategoryDTO.Request;
using ShoppingOnline.BLL.DataTransferObjects.OrderDTO;
using ShoppingOnline.BLL.DataTransferObjects.OrderItemDTO;
using ShoppingOnline.BLL.DataTransferObjects.ProductDTO;
using ShoppingOnline.BLL.DataTransferObjects.ProductDTO.Requests;
using ShoppingOnline.BLL.DataTransferObjects.ProductItemDTO;
using ShoppingOnline.BLL.DataTransferObjects.ProductItemDTO.Requests;
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
		CreateMap<UpdateProductItem, ProductItem>();
		CreateMap<ProductItemCreateRequest, ProductItem>();
		#endregion
		#region OrderMapping
		CreateMap<Order, GetOrder>();
		CreateMap<CreatedOrder, Order>().ForMember(opt=> opt.OrderItems, cfg=> cfg.MapFrom(c=>c.OrderItems));
		CreateMap<UpdateOrder, Order>();
		#endregion
		#region OrderItems
		CreateMap<OrderItem, GetOrderItems>().ReverseMap();
		CreateMap<CreatedOrderItem, OrderItem>();
		#endregion
		#region Brand
		CreateMap<Brand, GetBrand>();
		CreateMap<CreatedBrand, Brand>();
		CreateMap<UpdateBrand, Brand>();
		#endregion

		CreateMap<Category, CategoryViewModel>();

		CreateMap<CategoryCreateRequest, Category>();
		CreateMap<CategoryUpdateRequest, Category>();
	}
}
