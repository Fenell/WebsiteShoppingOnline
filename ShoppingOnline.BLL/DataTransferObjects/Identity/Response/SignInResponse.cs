namespace ShoppingOnline.BLL.DataTransferObjects.Identity.Response;

public class SignInResponse
{
	public string Id { get; set; } = null!;
	public string Email { get; set; } = null!;
	public string Token { get; set; } = null!;
}