using Newtonsoft.Json;

namespace ShoppingOnline.BLL.DataTransferObjects.Identity.Google;

public class IdTokenGoogle
{
	[JsonProperty("access_token")]
	public string AccessToken { get; set; }

	[JsonProperty("expires_in")]
	public long ExpiresIn { get; set; }

	[JsonProperty("id_token")]
	public string IdToken { get; set; }
}