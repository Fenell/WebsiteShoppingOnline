using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using ShoppingOnline.Admin.Constants;
using ShoppingOnline.Admin.Models.Auth;
using ShoppingOnline.Admin.Provider;
using ShoppingOnline.Admin.Services.Interface;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ShoppingOnline.Admin.Services.Implement;

public class AuthService : IAuthService
{
	private readonly ILocalStorageService _localStorageService;
	private readonly IHttpClientFactory _httpClientFactory;
	private readonly AuthenticationStateProvider _authState;

	public AuthService(ILocalStorageService localStorageService, IHttpClientFactory httpClientFactory, AuthenticationStateProvider authState)
	{
		_localStorageService = localStorageService;
		_httpClientFactory = httpClientFactory;
		_authState = authState;
	}

	public async Task<bool> Login(SignInVM vm)
	{
		var httpClient = _httpClientFactory.CreateClient(ApplicationConstant.ClientName);

		var response = await httpClient.PostAsJsonAsync("/api/Accounts/login", vm);
		var responseContent = await response.Content.ReadAsStringAsync();

		if (response.IsSuccessStatusCode)
		{
			var result = JsonConvert.DeserializeObject<SignInResponse>(responseContent);
			await _localStorageService.SetItemAsync("token", result?.Token);
	//		httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result?.Token);

			await ((AuthStateProvider)_authState).LogedIn();

			return true;
		}

		return false;
	}

	public async Task Logout()
	{
		var httpClient = _httpClientFactory.CreateClient(ApplicationConstant.ClientName);

		await _localStorageService.RemoveItemAsync("token");
		httpClient.DefaultRequestHeaders.Authorization = null;

		await ((AuthStateProvider)_authState).LogedOut();
	}
}