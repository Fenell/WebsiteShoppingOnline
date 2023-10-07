namespace ShoppingOnline.Admin.ViewModels.Auth;

public class SignInResponse
{
	public bool IsSuccess { get; set; }
	public string Id { get; set; } = null!;
	public string Email { get; set; } = null!;
	public string Token { get; set; } = null!;
}