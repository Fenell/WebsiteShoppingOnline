using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace ShoppingOnline.Admin.Provider;

public class AuthStateProvider : AuthenticationStateProvider
{
	private readonly ILocalStorageService _localStorageService;
	private readonly HttpClient _httpClient;
	private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

	public AuthStateProvider(ILocalStorageService localStorageService, HttpClient httpClient)
	{
		_localStorageService = localStorageService;
		_httpClient = httpClient;
		_jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
	}

	public override async Task<AuthenticationState> GetAuthenticationStateAsync()
	{
		var user = new ClaimsPrincipal(new ClaimsIdentity());
		var exists = await _localStorageService.ContainKeyAsync("token");

		if (!exists)
			return new AuthenticationState(user);

		var token = await _localStorageService.GetItemAsync<string>("token");
		var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(token);
		var userClaims = tokenContent.Claims.ToList();

		userClaims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));

		if (DateTime.UtcNow > tokenContent.ValidTo)
			return new AuthenticationState(user);

	//	_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
		user = new ClaimsPrincipal(new ClaimsIdentity(userClaims, "jwt"));

		return new AuthenticationState(user);
	}

	public async Task LogedIn()
	{
		var listClaims = await GetClaimsAsync();
		var user = new ClaimsIdentity(listClaims, "jwt");
		var authState = Task.FromResult(new AuthenticationState(new ClaimsPrincipal(user)));

		NotifyAuthenticationStateChanged(authState);
	}

	public async Task LogedOut()
	{
		var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
		var authState = Task.FromResult(new AuthenticationState(anonymous));

		NotifyAuthenticationStateChanged(authState);
	}

	private async Task<List<Claim>> GetClaimsAsync()
	{
		var token = await _localStorageService.GetItemAsync<string>("token");
		var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(token);
		var listClaims = tokenContent.Claims.ToList();
		listClaims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));

		return listClaims;
	}
}