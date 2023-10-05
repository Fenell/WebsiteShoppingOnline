using AutoMapper;
using ShoppingOnline.BLL.DataTransferObjects.ProductItemDTO;
using ShoppingOnline.BLL.Exceptions;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;

namespace ShoppingOnline.BLL.Features.ProductItemFeature;
public class ProductItemsServices : IProductItemServices
{
	private readonly IProductItemRepository _productItemRepository;
	private readonly IMapper _mapper;
	public ProductItemsServices(IProductItemRepository productItemRepository, IMapper mapper)
	{
		_productItemRepository = productItemRepository;
		_mapper = mapper;
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

	public async Task<GetProductItem> GetProductItemById(Guid id)
	{
		var productItem = await _productItemRepository.GetByIdAsync(id);
		var productItemMap = _mapper.Map<GetProductItem>(productItem);
		return productItemMap;
	}

	public async Task<IEnumerable<GetProductItem>> GetProductItems()
	{
		var productsItem = await _productItemRepository.GetProductItem();
		var productItemMap = _mapper.Map<IEnumerable<GetProductItem>>(productsItem);
		return productItemMap;
	}

	public async Task<bool> UpdateProductItem(UpdateProductItem updateProductItem)
	{
		var request = await _productItemRepository.GetByIdAsync(updateProductItem.Id);

		if (request == null)
			throw new NotFoundException(nameof(request), updateProductItem.Id);

		var productItemMap = _mapper.Map<UpdateProductItem, ProductItem>(updateProductItem, request);


		var productItemUpdate = await _productItemRepository.UpdateProductItem(productItemMap);
		return productItemUpdate;
	}
}
