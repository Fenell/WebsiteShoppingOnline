using ShoppingOnline.DAL.Database.AppDbContext;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;

namespace ShoppingOnline.DAL.Repositories.Implement;

public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
{
	private readonly ExtendedApplicationDbContext _extended;

	public CategoryRepository(ApplicationDbContext context, ExtendedApplicationDbContext extended) : base(context)
	{
		_extended = extended;
	}
}