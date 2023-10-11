using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ShoppingOnline.Client.Pages.Auth;

public partial class Login
{
	[Inject] public IJSRuntime JsRuntime { get; set; }


	private async Task LoginGoogleHandle()
	{
		await JsRuntime.InvokeVoidAsync("oauthSignIn");
	}
}