using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShoppingOnline.BLL.DataTransferObjects.Identity.Requests;
using ShoppingOnline.BLL.DataTransferObjects.Identity.Response;
using ShoppingOnline.BLL.Exceptions;
using ShoppingOnline.BLL.OptionModels;
using ShoppingOnline.DAL.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShoppingOnline.BLL.Features.Identity;

public class AuthService : IAuthService
{
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly SignInManager<ApplicationUser> _signInManager;
	private readonly JwtSettings _jwtSettings;

	public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
	{
		_userManager = userManager;
		_signInManager = signInManager;
		_jwtSettings = jwtSettings.Value;
	}

	public async Task<SignInResponse> Login(SignInRequest request)
	{
		var user = await _userManager.FindByEmailAsync(request.Email);

		if (user is null)
			throw new BadRequestExpection("Email or password incorrect");

		var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

		if (!result.Succeeded)
			throw new BadRequestExpection("Email or password incorrect");

		var jwtSecurity = await GenerateToken(user);

		return new()
		{
			Id = user.Id,
			Email = user.Email,
			Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurity)
		};
	}

	public async Task<RegistrationResponse> Register(RegistrationRequest request)
	{
		var existsUser = await _userManager.FindByEmailAsync(request.Email);
		if (existsUser is not null)
			throw new BadRequestExpection("Email already exists in the system");

		ApplicationUser user = new()
		{
			FirstName = request.FirstName,
			LastName = request.LastName,
			PhoneNumber = request.PhoneNumber,
			Email = request.Email,
			UserName = request.Email
		};

		var result = await _userManager.CreateAsync(user, request.Password);

		if (result.Succeeded)
		{
			await _userManager.AddToRoleAsync(user, "User");
			return new RegistrationResponse() { UserId = user.Id };
		}

		// Create obj StringBuilder stored all Error from result
		StringBuilder str = new();
		foreach (var err in result.Errors)
		{
			str.AppendFormat("{0}\n", err.Description);
		}

		throw new BadRequestExpection($"{str}");
	}

	private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
	{
		var userClaims = await _userManager.GetClaimsAsync(user);
		var roles = await _userManager.GetRolesAsync(user);
		var roleClaim = roles.Select(c => new Claim(ClaimTypes.Role, c)).ToList();

		var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.FirstName + " " + user.LastName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim("uid", user.Id), new Claim("FirstName", user.FirstName ?? ""),
				new Claim("LastName", user.LastName ?? "")
			}
			.Union(userClaims)
			.Union(roleClaim);

		var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
		var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

		var jwtSecurity = new JwtSecurityToken(
			issuer: _jwtSettings.Issuer,
			audience: _jwtSettings.Audience,
			claims: claims,
			signingCredentials: signingCredentials,
			expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes)
		);

		return jwtSecurity;
	}
}