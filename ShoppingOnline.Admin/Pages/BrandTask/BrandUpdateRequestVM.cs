namespace ShoppingOnline.Admin.Pages.BrandTask;

public class BrandUpdateRequestVM
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string Status { get; set; }
	public string? CreateBy { get; set; }
}
