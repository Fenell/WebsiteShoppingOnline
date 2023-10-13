using System.ComponentModel.DataAnnotations;

namespace ShoppingOnline.Admin.Models.Product;

public class ProductVM
{
	public Guid Id { get; set; }
	[Required]
	public Guid CategoryId { get; set; }
	[Required]
	public Guid BrandId { get; set; }
	public string CategoryName { get; set; }
	public string BrandName { get; set; }
	[Required]
	public string Name { get; set; } = null!;
	public string? Description { get; set; }
	public decimal Price { get; set; }
	public string Status { get; set; }
	public bool IsDeleted { get; set; }

}