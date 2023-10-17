using ShoppingOnline.DAL.Repositories.Identity;

namespace ShoppingOnline.DAL.Database.AppDbContext;

public class ExtendedApplicationDbContext
{
	private readonly ApplicationDbContext _context;
	private readonly IUserService _userService;

	public ExtendedApplicationDbContext(ApplicationDbContext context, IUserService userService)
	{
		_context = context;
		_userService = userService;
		_context.CurrentUserId =  _userService.GetUserIdAsync();
	}
}