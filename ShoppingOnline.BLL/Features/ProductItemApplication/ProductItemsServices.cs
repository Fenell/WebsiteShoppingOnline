using AutoMapper;
using ShoppingOnline.BLL.Dtos.ProductItemViewModel;
using ShoppingOnline.BLL.Exceptions;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Features.ProductItemApplication;
public class ProductItemsServices : IProductItemServices
{
	private readonly IProductItemRepository _productItemRepository;
	private readonly IMapper _mapper;
	public ProductItemsServices(IProductItemRepository productItemRepository, IMapper mapper)
	{
		_productItemRepository = productItemRepository;
		_mapper = mapper;
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
