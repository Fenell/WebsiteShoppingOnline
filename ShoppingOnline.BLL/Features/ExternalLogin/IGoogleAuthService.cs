using ShoppingOnline.BLL.DataTransferObjects.Identity.Google;

namespace ShoppingOnline.BLL.Features.ExternalLogin;

public interface IGoogleAuthService
{
	Task<GoogleUserInfo> GetGoogleUserInfo(string accessToken);
	Task<IdTokenGoogle> GetIdTokenGoogle(string authoCode);
}