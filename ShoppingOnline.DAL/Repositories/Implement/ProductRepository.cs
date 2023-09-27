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

	public Task<Guid> CreateProduct(Product product)
	{
		throw new NotImplementedException();
	}

	public Task<bool> DeleteProduct(Guid productId)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<Product>> GetAllProducts()
	{
		return await _genericRepository.GetAllAsync();
	}

	public Task<Product> GetProductById(Guid productId)
	{
		throw new NotImplementedException();
	}

	public Task<bool> UpdateProduct(Product product)
	{
		throw new NotImplementedException();
	}
}
