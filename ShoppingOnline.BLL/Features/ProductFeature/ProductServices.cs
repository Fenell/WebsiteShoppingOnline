using AutoMapper;
using ShoppingOnline.BLL.DataTransferObjects.ProductDTO;
using ShoppingOnline.BLL.Exceptions;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;

namespace ShoppingOnline.BLL.Features.ProductFeature;
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
				Quantity = create.Quantity,
				ProductImages = new List<ProductImage>()
			}
		};
		await _productRepository.CreateProduct(product);
		return product.Id;
	}

	public async Task<bool> DeleteHardProduct(DeleteProduct deleteProduct)
	{
		var product = await _productRepository.GetByIdAsync(deleteProduct.Id);
		if (product == null)
			throw new NotFoundException(nameof(product), deleteProduct.Id);

		return await _productRepository.DeleteAsync(product);
	}

	public async Task<bool> DeleteProduct(DeleteProduct deleteProduct)
	{
		var product = await _productRepository.GetProductById(deleteProduct.Id);

		if (product == null)
			throw new NotFoundException(nameof(product), deleteProduct.Id);

		product.IsDeleted = true;
		return await _productRepository.DeleteProduct(product);
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
