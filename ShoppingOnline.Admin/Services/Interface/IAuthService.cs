using ShoppingOnline.Admin.Models.Auth;

namespace ShoppingOnline.Admin.Services.Interface;

public interface IAuthService
{
	Task<bool> Login(SignInVM vm);

	Task Logout();
}