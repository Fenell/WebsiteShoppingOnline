using System.ComponentModel.DataAnnotations;

namespace ShoppingOnline.BLL.DataTransferObjects.Example.Request;

public class ExampleCreateRequest
{
	public string Name { get; set; } = null!;
	public string? CreateBy { get; set; }
}