using System.ComponentModel.DataAnnotations;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace ShoppingOnline.BLL.Exceptions;

public class BadRequestExpection : Exception
{
	public BadRequestExpection(string message) : base(message)
	{
	}

	//Bắn ra 1 ex với 1 danh sách validate failed (sử dụng trong Fluent Validation)
	public BadRequestExpection(string message, ValidationResult validationResult) : base(message)
	{
		ValidationErrors = validationResult.ToDictionary();
	}

	public IDictionary<string, string[]> ValidationErrors { get; set; }
}