using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.BLL.DataTransferObjects.Identity.Requests;
using ShoppingOnline.BLL.Features.ExternalLogin;
using ShoppingOnline.BLL.Features.Identity;

namespace ShoppingOnline.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
	private readonly IAuthService _authService;
	private readonly IGoogleAuthService _googleAuthService;

	public AccountsController(IAuthService authService, IGoogleAuthService googleAuthService)
	{
		_authService = authService;
		_googleAuthService = googleAuthService;
	}

	[HttpPost]
	[Route("login")]
	public async Task<IActionResult> Login(SignInRequest request)
	{
		var result = await _authService.Login(request);
		return Ok(result);
	}

	[HttpPost]
	[Route("register")]
	public async Task<IActionResult> Register(RegistrationRequest request)
	{
		var result = await _authService.Register(request);
		return Ok(result);
	}

	[HttpPost]
	[Route("google-login")]
	public async Task<IActionResult> LoginWithGoogle([FromBody] string authoCode)
	{
		var tokenAuthen = await _googleAuthService.GetIdTokenGoogle(authoCode);

		var response = await _authService.LoginWithGoogle(tokenAuthen.AccessToken);

		return Ok(response);
	}
}