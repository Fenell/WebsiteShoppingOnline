using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ShoppingOnline.DAL.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ShoppingOnline.DAL.Repositories.Identity;

public class UserService:IUserService
{
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly IHttpContextAccessor _httpContextAccessor;

	public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
	{
		_userManager = userManager;
		_httpContextAccessor = httpContextAccessor;
	}

	public string? UserId => _httpContextAccessor.HttpContext.User.FindFirstValue("uid");

	public string? GetUserIdAsync()
	{
		return  _httpContextAccessor.HttpContext.User.FindFirstValue("uid");
	}

	public async Task<string?> GetUserNameAsync(string userId)
	{
		var user = await _userManager.FindByIdAsync(userId);
		if(user is not null)
		{
			return user.FirstName + " " + user.LastName;
		}
		return null;
	}

	public async Task<ApplicationUser> GetUser(string userId)
	{
		var user = await _userManager.FindByIdAsync(userId);
		return user;
	}
}