using ShoppingOnline.DAL.Database.AppDbContext;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Repositories.Implement;
public class ProductRepository : GenericRepository<Product>, IProductRepository
{
	private readonly IGenericRepository<Product> _genericRepository;
	public ProductRepository(ApplicationDbContext context, IGenericRepository<Product> genericRepository) : base(context)
	{
		_genericRepository = genericRepository;
	}

	public async Task<Guid> CreateProduct(Product product)
	{
		try
		{
			var request = await _genericRepository.CreateAsync(product);
			return product.Id;
		}
		catch (Exception)
		{
			throw;
		}
	}

	public async Task<bool> DeleteProduct(Product product)
	{
		try
		{
			var request = await _genericRepository.UpdateAsync(product);
			return request;
		}
		catch (Exception)
		{
			return false;
			throw;
		}
	}

	public async Task<IEnumerable<Product>> GetAllProducts()
	{
		return await _genericRepository.GetAllAsync();
	}

	public async Task<Product> GetProductById(Guid productId)
	{
		return await _genericRepository.GetByIdAsync(productId);
	}

	public async Task<bool> UpdateProduct(Product product)
	{
		try
		{
			var request = await _genericRepository.UpdateAsync(product);
			return request;
		}
		catch (Exception)
		{
			return false;
			throw;
		}
	}
}
