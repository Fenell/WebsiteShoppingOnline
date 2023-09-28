using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.BLL.DataTransferObjects.Identity.Requests;
using ShoppingOnline.BLL.Features.Identity;

namespace ShoppingOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
	    private readonly IAuthService _authService;

	    public AccountsController(IAuthService authService)
	    {
		    _authService = authService;
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
    }
}
