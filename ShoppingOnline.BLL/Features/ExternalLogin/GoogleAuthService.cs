using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using ShoppingOnline.BLL.DataTransferObjects.Identity.Google;
using ShoppingOnline.BLL.OptionModels;

namespace ShoppingOnline.BLL.Features.ExternalLogin;

public class GoogleAuthService : IGoogleAuthService
{
	private readonly GoogleAuthSettings _googleSettings;
	private const string GoogleUserInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo?access_token={0}";

	public GoogleAuthService(IOptions<GoogleAuthSettings> googleSettings)
	{
		_googleSettings = googleSettings.Value;
	}

	public async Task<GoogleUserInfo> GetGoogleUserInfo(string accessToken)
	{
		string formatedUrl = string.Format(GoogleUserInfoUrl, accessToken);
		var restClient = new RestClient(formatedUrl);
		var request = new RestRequest() { Method = Method.Get };
		var response = await restClient.ExecuteAsync(request);

		return JsonConvert.DeserializeObject<GoogleUserInfo>(response.Content);
	}

	public async Task<IdTokenGoogle> GetIdTokenGoogle(string authoCode)
	{
		var restClient = new RestClient("https://oauth2.googleapis.com/token");
		var request = new RestRequest() { Method = Method.Post };
		request.AddParameter("code", authoCode);
		request.AddParameter("client_id", _googleSettings.ClientId);
		request.AddParameter("client_secret", _googleSettings.ClientSecret);
		request.AddParameter("redirect_uri", _googleSettings.RedirectUri);
		request.AddParameter("grant_type", "authorization_code");

		var response = await restClient.ExecuteAsync(request);
		return JsonConvert.DeserializeObject<IdTokenGoogle>(response.Content);
	}
}