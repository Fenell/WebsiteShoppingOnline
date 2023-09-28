using Microsoft.AspNetCore.Identity;

namespace ShoppingOnline.DAL.Entities.Identity;

public class ApplicationUser : IdentityUser
{
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
}