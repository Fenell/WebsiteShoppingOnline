namespace ShoppingOnline.Admin.ViewModels.ViewModelClient;

public class BrandVM
{
	// Tạo view model hứng dữ liệu từ API
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string Status { get; set; }
	public string? CreateBy { get; set; }
}
