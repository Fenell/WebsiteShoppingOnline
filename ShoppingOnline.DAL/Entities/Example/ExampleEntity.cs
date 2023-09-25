using ShoppingOnline.DAL.Entities.Common;

namespace ShoppingOnline.DAL.Entities.Example;

public class ExampleEntity:BaseEntity
{
	public Guid Id { get; set; }
	public string Name { get; set; } = null!;
	
}