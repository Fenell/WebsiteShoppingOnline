using AutoMapper;
using ShoppingOnline.BLL.Dtos.ProductViewModel;
using ShoppingOnline.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Features.ProductApplication;
public class ProductServices : IProductServices
{
	private readonly IProductRepository _productRepository;
	private readonly IMapper _mapper;
	public ProductServices(IProductRepository productRepository, IMapper mapper)
	{
		_productRepository = productRepository;
		_mapper = mapper;
	}
	public async Task<IEnumerable<GetProducts>> GetAllProducts()
	{
		var products = await _productRepository.GetAllProducts();
		var productsMap = _mapper.Map<IEnumerable<GetProducts>>(products);
		return productsMap;
	}
}
