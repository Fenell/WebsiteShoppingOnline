using AutoMapper;
using ShoppingOnline.BLL.DataTransferObjects.ProductItemDTO;
using ShoppingOnline.BLL.DataTransferObjects.ProductItemDTO.Requests;
using ShoppingOnline.BLL.Exceptions;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;

namespace ShoppingOnline.BLL.Features.ProductItemFeature;

public class ProductItemsServices : IProductItemServices
{
	private readonly IProductItemRepository _productItemRepository;
	private readonly IMapper _mapper;
	private readonly IColorRepository _colorRepository;
	private readonly ISizeRepository _sizeRepository;
	private readonly IProductRepository _productRepository;

	public ProductItemsServices(IProductItemRepository productItemRepository, IMapper mapper, IColorRepository colorRepository,
		ISizeRepository sizeRepository, IProductRepository productRepository)
	{
		_productItemRepository = productItemRepository;
		_mapper = mapper;
		_colorRepository = colorRepository;
		_sizeRepository = sizeRepository;
		_productRepository = productRepository;
	}

	public async Task<List<GetProductItem>> GetProductItems()
	{
		var lst = await GetProductItemWithJoin();
		return lst.ToList();
	}

	public async Task<List<GetProductItem>> GetProductItemWithProductId(Guid productId)
	{
		var listProductItemWithJoin = await GetProductItemWithJoin();
		return listProductItemWithJoin.Where(c => c.ProductId == productId).ToList();
	}

	public async Task<GetProductItem?> GetProductItemById(Guid id)
	{
		var lstProductItemJoin = await GetProductItemWithJoin();
		var productItemWithJoin = lstProductItemJoin.FirstOrDefault(c => c.Id == id);

		return productItemWithJoin;
	}
	public async Task<GetProductItem> GetProductItemChienById(Guid id)
	{
		var productItem = await _productItemRepository.GetByIdAsync(id);
		var productItemMap = _mapper.Map<GetProductItem>(productItem);
		return productItemMap;
	}

	public async Task<bool> CreateListProductItem(Guid productId, List<ProductItemCreateRequest> requests)
	{
		var listProductItem = await GetProductItemWithProductId(productId);
		List<ProductItem> lstProductItemsCreat = new();
		foreach (var item in requests)
		{
			if (listProductItem.Any(c => c.SizeId == item.SizeId && c.ColorId == item.ColorId))
				throw new BadRequestExpection($"The product item with color id:{item.ColorId} and size id: {item.SizeId}  already exists");

			var productItemCreate = new ProductItem()
			{
				ProductId = productId,
				SizeId = item.SizeId,
				ColorId = item.ColorId,
				Quantity = item.Quantity,
				CreatedAt = DateTime.Now,
			};
			lstProductItemsCreat.Add(productItemCreate);
		}

		return await _productItemRepository.CreateRangeAsync(lstProductItemsCreat) > 0;
	}

	public async Task<bool> DeleteHardProductItem(DeleteProductItem deletedHardProductItem)
	{
		var request = await _productItemRepository.GetByIdAsync(deletedHardProductItem.Id);

		if (request == null)
			throw new NotFoundException(nameof(request), deletedHardProductItem.Id);

		return await _productItemRepository.DeleteAsync(request);
	}

	public async Task<bool> DeleteProductItem(DeleteProductItem deleteProductItem)
	{
		var request = await _productItemRepository.GetByIdAsync(deleteProductItem.Id);

		if (request == null)
			throw new NotFoundException(nameof(request), deleteProductItem.Id);
		request.IsDeleted = true;

		return await _productItemRepository.DeleteProductItem(request);
	}

	public async Task<bool> UpdateProductItem(UpdateProductItem updateProductItem)
	{
		var request = await _productItemRepository.GetByIdAsync(updateProductItem.Id);

		if (request == null)
			throw new NotFoundException(nameof(request), updateProductItem.Id);

		var listProductItem = await GetProductItemWithProductId(updateProductItem.ProductId);

		if (listProductItem.Any(c => c.SizeId == updateProductItem.SizeId && c.ColorId == updateProductItem.ColorId))
			throw new BadRequestExpection(
				$"The product item with color id:{updateProductItem.ColorId} and size id: {updateProductItem.SizeId}  already exists");

		var productItemMap = _mapper.Map<UpdateProductItem, ProductItem>(updateProductItem, request);
		var productItemUpdate = await _productItemRepository.UpdateProductItem(productItemMap);

		return productItemUpdate;
	}

	private async Task<IQueryable<GetProductItem>> GetProductItemWithJoin()
	{
		var listProductItems = await _productItemRepository.GetAllAsync();

		var listColors = await _colorRepository.GetAllAsync();
		var listSizes = await _sizeRepository.GetAllAsync();
		var listProducts = await _productRepository.GetAllAsync();

		var listJoin = (from productItem in listProductItems
						join product in listProducts on productItem.ProductId equals product.Id
						join color in listColors on productItem.ColorId equals color.Id
						join size in listSizes on productItem.SizeId equals size.Id
						select new GetProductItem()
						{
							Id = productItem.Id,
							ProductId = product.Id,
							ProductName = product.Name,
							ColorId = color.Id,
							ColorName = color.Name,
							SizeId = size.Id,
							SizeName = size.Name,
							Quantity = productItem.Quantity,
							Status = productItem.Status
						});

		return listJoin;
	}

	
}