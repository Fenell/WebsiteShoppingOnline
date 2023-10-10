namespace ShoppingOnline.Client.Services.Interface;

public interface IAuthService
{
	Task<bool> LoginWithGoogle(string authoCode);
	Task Logout();
}