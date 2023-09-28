using AutoMapper;
using ShoppingOnline.BLL.Dtos.ProductViewModel;
using ShoppingOnline.BLL.Exceptions;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

	public async Task<Guid> CreateProduct(CreateProduct create)
	{
		var product = _mapper.Map<CreateProduct, Product>(create);
		product.ProductItems = new List<ProductItem>()
		{
			new ProductItem()
			{
				ColorId = create.ColorId,
				SizeId = create.SizeId,
				Quantity = create.Quantity
			}
		};
		await _productRepository.CreateProduct(product);
		return product.Id;
	}

	public async Task<bool> DeleteProduct(Product delete)
	{
		var product = await _productRepository.GetProductById(delete.Id);

		if (product == null)
			throw new NotFoundException(nameof(product), delete.Id);

		product.IsDeleted = delete.IsDeleted;
		var deleteProduct = await _productRepository.DeleteAsync(product);
		return deleteProduct;
	}

	public async Task<IEnumerable<GetProducts>> GetAllProducts()
	{
		var products = await _productRepository.GetAllProducts();
		var productsMap = _mapper.Map<IEnumerable<GetProducts>>(products);
		return productsMap;
	}

	public async Task<GetProducts> GetProductById(Guid productId)
	{
		var product = await _productRepository.GetProductById(productId);
		var productMap = _mapper.Map<GetProducts>(product);
		return productMap;
	}

	public async Task<bool> UpdateProduct(UpdateProduct update)
	{
		var product = await _productRepository.GetProductById(update.Id);

		if (product == null)
			throw new NotFoundException(nameof(product), update.Id);

		var productMap = _mapper.Map<UpdateProduct, Product>(update, product);
		update.UpdateAt = DateTime.Now;
		var updateProduct = await _productRepository.UpdateProduct(productMap);
		return updateProduct;
	}
}
