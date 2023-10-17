namespace ShoppingOnline.Admin.ViewModels.ViewModelClient;

public class BrandVM
{
	// Tạo view model hứng dữ liệu từ API
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string Status { get; set; }
	public DateTime CreatedAt { get; set; } 
	public string? CreatedBy { get; set; }
	public DateTime UpdateAt { get; set; }
	public string? UpdateBy { get; set; }
	public string? CreatedUserName { get; set; }
	public string? UpdatedUserName { get; set; }
}
