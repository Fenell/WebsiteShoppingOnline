using ShoppingOnline.DAL.Entities.Identity;

namespace ShoppingOnline.DAL.Repositories.Identity;

public interface IUserService
{
	public string? UserId { get; }
	string? GetUserIdAsync();
	Task<string?> GetUserNameAsync(string userId);
	Task<ApplicationUser> GetUser(string userId);
}