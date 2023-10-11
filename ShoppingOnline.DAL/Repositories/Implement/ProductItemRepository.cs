using ShoppingOnline.DAL.Database.AppDbContext;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Repositories.Implement;
public class ProductItemRepository : GenericRepository<ProductItem>, IProductItemRepository
{
	private readonly IGenericRepository<ProductItem> _genericRepository;
	private readonly ApplicationDbContext _context;
	public ProductItemRepository(ApplicationDbContext context, IGenericRepository<ProductItem> genericRepository) : base(context)
	{
		_context = context;
		_genericRepository = genericRepository;
	}

	public async Task<bool> DeleteProductItem(ProductItem productItem)
	{
		try
		{
			var request = await _genericRepository.UpdateAsync(productItem);
			return true;
		}
		catch (Exception)
		{
			return false;
			throw;
		}
	}

	public async Task<bool> UpdateProductItemRange(ProductItem productItem)
	{
		try
		{
			_context.ProductItems.UpdateRange(productItem);
			await _context.SaveChangesAsync();
			return true;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}

	public async Task<IEnumerable<ProductItem>> GetProductItem()
	{
		return await _genericRepository.GetAllAsync();
	}

	public async Task<ProductItem> GetProductItemById(Guid id)
	{
		return await _genericRepository.GetByIdAsync(id);
	}

	public async Task<bool> UpdateProductItem(ProductItem productItem)
	{
		try
		{
			var request = await _genericRepository.UpdateAsync(productItem);
			return request;
		}
		catch (Exception)
		{
			return false;
			throw;
		}
	}
}
