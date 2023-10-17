using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ShoppingOnline.Admin.Provider;
using System.Net;
using System.Net.Http.Headers;

namespace ShoppingOnline.Admin.Handler;

public class CustomMessageHandler:DelegatingHandler
{
	private readonly ILocalStorageService _localStorageService;
	private readonly AuthenticationStateProvider _authState;
	private readonly NavigationManager _navigationManager;

	public CustomMessageHandler(ILocalStorageService localStorageService, AuthenticationStateProvider authState, 
		NavigationManager navigationManager)
	{
		_localStorageService = localStorageService;
		_authState = authState;
		_navigationManager = navigationManager;
	}

	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		var token = await _localStorageService.GetItemAsync<string>("token", cancellationToken);
		if (!string.IsNullOrEmpty(token))
		{
			request.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
		}

		var response = await base.SendAsync(request, cancellationToken);
		if (response.StatusCode == HttpStatusCode.Unauthorized)
		{
			 await ((AuthStateProvider)_authState).LogedOut();
			 _navigationManager.NavigateTo("/login", true);
		}

		return response;
	}
}