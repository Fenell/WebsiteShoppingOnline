using ShoppingOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Repositories.Interface;
public interface IBrandRepository : IGenericRepository<Brand>
{
	Task<IEnumerable<Brand>> GetAllBrands();
	Task<Brand> GetBrandById(Guid id);
	Task<Guid> CreatedBrand(Brand brand);
	Task<bool> UpdateBrand(Brand brand);
	Task<bool> DeleteBrand(Brand brand);
}
