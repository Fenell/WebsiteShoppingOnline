using ShoppingOnline.Admin.ViewModels.Auth;

namespace ShoppingOnline.Admin.Services.Interface;

public interface IAuthService
{
	Task<bool> Login(SignInVM vm);

	Task Logout();
}