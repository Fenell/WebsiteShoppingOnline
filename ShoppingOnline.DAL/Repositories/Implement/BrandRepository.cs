using ShoppingOnline.DAL.Database.AppDbContext;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;

namespace ShoppingOnline.DAL.Repositories.Implement;

public class BrandRepository : GenericRepository<Brand>, IBrandRepository
{
	public BrandRepository(ApplicationDbContext context) : base(context)
	{
	}
}