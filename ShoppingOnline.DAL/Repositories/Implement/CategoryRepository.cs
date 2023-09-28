using ShoppingOnline.DAL.Database.AppDbContext;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;

namespace ShoppingOnline.DAL.Repositories.Implement;

public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
{
	public CategoryRepository(ApplicationDbContext context) : base(context)
	{
	}
}