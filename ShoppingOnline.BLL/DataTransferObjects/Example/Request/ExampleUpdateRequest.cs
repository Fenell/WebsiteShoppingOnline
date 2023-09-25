namespace ShoppingOnline.BLL.DataTransferObjects.Example.Request;

public class ExampleUpdateRequest
{
	public Guid Id { get; set; }
	public string Name { get; set; } = null!;
	public string? UpdatedBy { get; set; }
}