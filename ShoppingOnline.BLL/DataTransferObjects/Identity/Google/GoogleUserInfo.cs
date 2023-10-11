using Newtonsoft.Json;

namespace ShoppingOnline.BLL.DataTransferObjects.Identity.Google;

public class GoogleUserInfo
{
	[JsonProperty("email")]
	public string Email { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("given_name")]
	public string GivenName { get; set; }

	[JsonProperty("family_name")]
	public string FamilyName { get; set; }

	[JsonProperty("picture")]
	public Uri Picture { get; set; }
}