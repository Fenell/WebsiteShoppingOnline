using System.ComponentModel.DataAnnotations;

namespace ShoppingOnline.Admin.Models.Product;

public class ProductUpdateRequest
{
	public Guid Id { get; set; }
	[Required]
	public Guid CategoryId { get; set; }
	[Required]
	public Guid BrandId { get; set; }
	[Required]
	public string Name { get; set; } = null!;
	public decimal Price { get; set; }
	public string? Description { get; set; }
	public string? DefaultImage { get; set; }
	public DateTime UpdateAt { get; set; }
}