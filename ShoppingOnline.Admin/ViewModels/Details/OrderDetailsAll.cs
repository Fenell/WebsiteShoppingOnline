namespace ShoppingOnline.Admin.ViewModels.Details;

public class OrderDetailsAll
{
	public Guid Id { get; set; }
	public Guid IdProdctItems { get; set; }
	public string Name { get; set; }
	public string ColorName { get; set; }
	public string SizeName { get; set; }
	public Guid ColorId { get; set; }
	public Guid SizeId { get; set; }
	public int Quantity { get; set; }

}
