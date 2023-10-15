using AutoMapper;
using ShoppingOnline.BLL.DataTransferObjects.ProductDTO;
using ShoppingOnline.BLL.DataTransferObjects.ProductDTO.Requests;
using ShoppingOnline.BLL.Exceptions;
using ShoppingOnline.DAL.Constants;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;

namespace ShoppingOnline.BLL.Features.ProductFeature;
public class ProductServices : IProductServices
{
	private readonly IProductRepository _productRepository;
	private readonly IMapper _mapper;
	private readonly IBrandRepository _brandRepository;
	private readonly ICategoryRepository _categoryRepository;

	public ProductServices(IProductRepository productRepository, IMapper mapper, IBrandRepository brandRepository,
		ICategoryRepository categoryRepository)
	{
		_productRepository = productRepository;
		_mapper = mapper;
		_brandRepository = brandRepository;
		_categoryRepository = categoryRepository;
	}

	public async Task<Guid> CreateProduct(CreateProduct request)
	{
		var product = _mapper.Map<CreateProduct, Product>(request);
		await _productRepository.CreateProduct(product);

		return product.Id;
	}

	public async Task<bool> DeleteHardProduct(StatusChangeRequest deleteProduct)
	{
		var product = await _productRepository.GetByIdAsync(deleteProduct.Id);
		if (product == null)
			throw new NotFoundException(nameof(product), deleteProduct.Id);

		return await _productRepository.DeleteAsync(product);
	}

	public async Task<bool> SwitchStatusProduct(StatusChangeRequest request)
	{
		var product = await _productRepository.GetByIdAsync(request.Id);

		if (product == null)
			throw new NotFoundException(nameof(product), request.Id);
		if (product.IsDeleted == false)
		{
			product.IsDeleted = true;
			product.UpdateAt = DateTime.Now;
			product.Status = EntityStatus.Deleted;
			return await _productRepository.UpdateAsync(product);
		}
		product.IsDeleted = false;
		product.UpdateAt = DateTime.Now;
		product.Status = EntityStatus.Active;
		return await _productRepository.UpdateAsync(product);
	}

	public async Task<IReadOnlyList<GetProducts>> GetAllProducts()
	{
		var products = await JoinProductWithBrandAndCate();

		return products.ToList();
	}

	public async Task<GetProducts> GetProductById(Guid productId)
	{
		var listProducts = await JoinProductWithBrandAndCate();
		var product = listProducts.FirstOrDefault(c=>c.Id == productId);

		if (product == null)
			throw new NotFoundException(nameof(product), productId);

		return product;
	}

	public async Task<bool> UpdateProduct(UpdateProduct request)
	{
		var product = await _productRepository.GetProductById(request.Id);

		if (product == null)
			throw new NotFoundException(nameof(product), request.Id);

		var productMap = _mapper.Map<UpdateProduct, Product>(request, product);
		request.UpdateAt = DateTime.Now;
		var updateProduct = await _productRepository.UpdateProduct(productMap);
		return updateProduct;
	}

	private async Task<IQueryable<GetProducts>> JoinProductWithBrandAndCate()
	{
		var products = await _productRepository.GetAllAsync();
		var categories = await _categoryRepository.GetAllAsync();
		var brands = await _brandRepository.GetAllAsync();

		var productJoin = (from product in products
			join brand in brands on product.BrandId equals brand.Id
			join category in categories on product.CategoryId equals category.Id
			select new GetProducts()
			{
				Id = product.Id,
				Name = product.Name,
				BrandId = brand.Id,
				CategoryId = category.Id,
				BrandName = brand.Name,
				CategoryName = category.Name,
				Description = product.Description,
				Price = product.Price,
				Status = product.Status,
				IsDeleted = product.IsDeleted
			});

		return productJoin;
	}
}
