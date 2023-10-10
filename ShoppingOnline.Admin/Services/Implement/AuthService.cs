using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using ShoppingOnline.Admin.Provider;
using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.Auth;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ShoppingOnline.Admin.Services.Implement;

public class AuthService : IAuthService
{
	private readonly ILocalStorageService _localStorageService;
	private readonly HttpClient _httpClient;
	private readonly AuthenticationStateProvider _authState;

	public AuthService(ILocalStorageService localStorageService, HttpClient httpClient, AuthenticationStateProvider authState)
	{
		_localStorageService = localStorageService;
		_httpClient = httpClient;
		_authState = authState;
	}

	public async Task<bool> Login(SignInVM vm)
	{
		var response = await _httpClient.PostAsJsonAsync("/api/Accounts/login", vm);
		var responseContent = await response.Content.ReadAsStringAsync();

		if (response.IsSuccessStatusCode)
		{
			var result = JsonConvert.DeserializeObject<SignInResponse>(responseContent);
			await _localStorageService.SetItemAsync("token", result?.Token);
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result?.Token);
			await ((AuthStateProvider)_authState).LogedIn();

			return true;
		}

		return false;
	}

	public async Task Logout()
	{
		await _localStorageService.RemoveItemAsync("token");
		_httpClient.DefaultRequestHeaders.Authorization = null;
		await ((AuthStateProvider)_authState).LogedOut();
	}
}