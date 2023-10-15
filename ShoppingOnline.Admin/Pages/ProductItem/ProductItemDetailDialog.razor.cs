using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ShoppingOnline.Admin.Models.ProductImage;
using ShoppingOnline.Admin.Models.ProductItem;
using ShoppingOnline.Admin.Services.Interface;
using System.Net.Http.Headers;

namespace ShoppingOnline.Admin.Pages.ProductItem;

public partial class ProductItemDetailDialog
{
	[CascadingParameter] MudDialogInstance MudDialog { get; set; }
	[Parameter] public Guid ProductItemId { get; set; }
	[Parameter] public Guid ProductId { get; set; }
	[Inject] public IProductItemService ProductItemService { get; set; }
	[Inject] public IProductImageService ProductImageService { get; set; }
	[Inject] public ISnackbar Snackbar { get; set; }

	public ProductItemVM ProductItem { get; set; } = new();
	public List<ProductItemCreateRequest> ProductItemCreates { get; set; } = new();
	public List<ColorVM> ListColors { get; set; } = new();
	public List<SizeVM> ListSizes { get; set; } = new();
	public List<string> LstImageUrl { get; set; }
	public List<ProductImageVM> ProductImageVms { get; set; }
	public IReadOnlyList<IBrowserFile> BrowserFiles { get; set; }

	protected override async Task OnInitializedAsync()
	{
		if (ProductItemId != Guid.Empty)
		{
			ProductItem = await ProductItemService.GetProductItemById(ProductItemId);
			ProductImageVms = await ProductImageService.GetAllProducts(ProductItemId);
			LstImageUrl = new();
			ProductImageVms.ForEach(c => LstImageUrl.Add(c.ImageUrl));
		}

		ListColors = await ProductItemService.GetAllColor();
		ListSizes = await ProductItemService.GetAllSize();
	}

	private async Task HandleAction()
	{


		if (ProductItemId != Guid.Empty)
		{
			if (BrowserFiles.Any())
			{
				await ProductImageService.CreateProductItem(ProductItemId, BrowserFiles);
			}

			var productItemUpdate = new ProductItemUpdateRequest()
			{
				Id = ProductItemId,
				SizeId = ProductItem.SizeId,
				ColorId = ProductItem.ColorId,
				Quantity = ProductItem.Quantity
			};
			var result = await ProductItemService.UpdateProductItem(productItemUpdate);

			if (result)
			{
				Snackbar.Add("Cập nhật thành công", Severity.Success);
				MudDialog.Close(DialogResult.Ok(true));
			}
		}
		else
		{
			var productItemCreate = new ProductItemCreateRequest()
			{
				SizeId = ProductItem.SizeId,
				ColorId = ProductItem.ColorId,
				Quantity = ProductItem.Quantity
			};
			ProductItemCreates.Add(productItemCreate);
			var result = await ProductItemService.CreateProducItem(ProductId, ProductItemCreates);

			if (result)
			{
				Snackbar.Add("Tạo mới thành công", Severity.Success);
				MudDialog.Close(DialogResult.Ok(true));
			}
		}
	}

	private async Task OnInputFileChanged(InputFileChangeEventArgs e)
	{
		LstImageUrl.Clear();
		var files = e.GetMultipleFiles(4);
		BrowserFiles = files;
		foreach (var item in files)
		{
			var buffers = new byte[item.Size];
			await item.OpenReadStream(Int64.MaxValue).ReadAsync(buffers);
			string imageType = item.ContentType;
			var imgUrl = $"data:{imageType};base64,{Convert.ToBase64String(buffers)}";
			LstImageUrl.Add(imgUrl);
		}
	}

	private void Edit()
	{
		Snackbar.Add("sdlkfjs;dlfjs", Severity.Success);
	}
}