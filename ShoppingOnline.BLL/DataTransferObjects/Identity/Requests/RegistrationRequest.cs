using System.ComponentModel.DataAnnotations;

namespace ShoppingOnline.BLL.DataTransferObjects.Identity.Requests;

public class RegistrationRequest
{
	[Required] public string Email { get; set; } = null!;

	[Required] public string FirstName { get; set; } = null;

	[Required] public string LastName { get; set; } = null!;

	[Required] public string Password { get; set; } = null!;

	[Required] public string PhoneNumber { get; set; } = null!;
}