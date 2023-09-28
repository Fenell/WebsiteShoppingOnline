using ShoppingOnline.BLL.DataTransferObjects.Identity.Requests;
using ShoppingOnline.BLL.DataTransferObjects.Identity.Response;

namespace ShoppingOnline.BLL.Features.Identity;

public interface IAuthService
{
	Task<SignInResponse> Login(SignInRequest request);

	Task<RegistrationResponse> Register(RegistrationRequest request);
}