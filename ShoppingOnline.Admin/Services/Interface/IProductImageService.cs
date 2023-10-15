using Microsoft.AspNetCore.Components.Forms;
using ShoppingOnline.Admin.Models.ProductImage;

namespace ShoppingOnline.Admin.Services.Interface;

public interface IProductImageService
{
	Task<bool> CreateProductItem(Guid productItemId, IReadOnlyList<IBrowserFile> files);

	Task<List<ProductImageVM>> GetAllProducts(Guid productItemId);
}