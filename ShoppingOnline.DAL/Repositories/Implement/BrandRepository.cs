using ShoppingOnline.DAL.Database.AppDbContext;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Repositories.Implement;
public class BrandRepository : GenericRepository<Brand>, IBrandRepository
{
	private readonly IGenericRepository<Brand> _genericRepository;
	public BrandRepository(ApplicationDbContext context, IGenericRepository<Brand> genericRepository) : base(context)
	{
		_genericRepository = genericRepository;

	}

	public Task<Guid> CreatedBrand(Brand brand)
	{
		var request = _genericRepository.CreateAsync(brand);
		return request;
	}

	public async Task<bool> DeleteBrand(Brand brand)
	{
		var request = await _genericRepository.DeleteAsync(brand);
		return request;
	}

	public async Task<IEnumerable<Brand>> GetAllBrands()
	{
		return await _genericRepository.GetAllAsync();
	}

	public async Task<Brand> GetBrandById(Guid id)
	{
		return await _genericRepository.GetByIdAsync(id);
	}

	public async Task<bool> UpdateBrand(Brand brand)
	{
		var request = await _genericRepository.UpdateAsync(brand);
		return request;
	}
}
