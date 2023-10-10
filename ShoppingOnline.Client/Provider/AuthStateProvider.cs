using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ShoppingOnline.Client.Provider;

public class AuthStateProvider : AuthenticationStateProvider
{
	private readonly ILocalStorageService _localStorageService;
	private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

	public AuthStateProvider(ILocalStorageService localStorageService)
	{
		_localStorageService = localStorageService;
		_jwtSecurityTokenHandler = new();
	}

	public override async Task<AuthenticationState> GetAuthenticationStateAsync()
	{
		var user = new ClaimsPrincipal(new ClaimsIdentity());
		var existsToken = await _localStorageService.ContainKeyAsync("token");

		if (!existsToken)
			return new AuthenticationState(user);

		var token = await _localStorageService.GetItemAsync<string>("token");
		var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(token);
		var userClaims = tokenContent.Claims.ToList();

		if (tokenContent.ValidTo < DateTime.UtcNow)
			return new AuthenticationState(user);

		userClaims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
		user = new ClaimsPrincipal(new ClaimsIdentity(userClaims, "jwt"));

		return new AuthenticationState(user);
	}

	public async Task LogedIn()
	{
		var listClaims = await GetClaimsAsync();
		var user = new ClaimsPrincipal(new ClaimsIdentity(listClaims, "jwt"));
		var authState = Task.FromResult(new AuthenticationState(user));

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