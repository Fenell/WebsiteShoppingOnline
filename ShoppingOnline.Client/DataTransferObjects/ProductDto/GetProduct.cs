﻿namespace ShoppingOnline.Client.DataTransferObjects.ProductDto;

public class GetProduct
{
	public Guid Id { get; set; }
	public Guid CategoryId { get; set; }
	public Guid BrandId { get; set; }
	public string Name { get; set; } = null!;
	public string? SeoTitle { get; set; }
	public decimal Price { get; set; }
	public decimal Discount { get; set; }
	public string? Description { get; set; }
	public string? DefaultImage { get; set; }
	public string Status { get; set; }
}
