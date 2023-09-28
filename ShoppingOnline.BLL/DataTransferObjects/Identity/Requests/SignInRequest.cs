namespace ShoppingOnline.BLL.DataTransferObjects.Identity.Requests;

public class SignInRequest
{
	public string Email { get; set; } = null!;
	public string Password { get; set; } = null!;
}