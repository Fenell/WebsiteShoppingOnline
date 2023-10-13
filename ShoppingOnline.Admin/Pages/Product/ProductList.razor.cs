using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using ShoppingOnline.Admin.Models.Product;
using ShoppingOnline.Admin.Pages.ProductItem;
using ShoppingOnline.Admin.Services.Interface;

namespace ShoppingOnline.Admin.Pages.Product;

public partial class ProductList
{
	[Inject] public IProductService ProductService { get; set; }
	[Inject] public IProductItemService ProductItemService { get; set; }
	[Inject] public ISnackbar SnackbarService { get; set; }
	[Inject] public IDialogService DialogService { get; set; }
	private IEnumerable<ProductVM> ListProducts = new List<ProductVM>();
	private ProductVM SelectedProduct { get; set; } = new();
	private bool IsProcessing;

	protected override async Task OnInitializedAsync()
	{
		IsProcessing = true;
		await LoadData();
		IsProcessing = false;
	}

	private async Task LoadData()
	{
		ListProducts = await ProductService.GetAllProduct();
		StateHasChanged();
	}

	private async void SwitchStatus(Guid id)
	{
		var result = await ProductService.ChangeStatus(id);

		if (result)
		{
			SnackbarService.Add("Chuyển trạng thái thành công", Severity.Success);
			await LoadData();
		}
		else
		{
			SnackbarService.Add("Có lỗi xảy ra", Severity.Error);
		}
	}


	private async Task EditProduct(Guid id)
	{
		SelectedProduct = await ProductService.GetProduct(id);
		var parameters = new DialogParameters<EditProductDialog>();
		parameters.Add(c => c.ProductVm, SelectedProduct);
		parameters.Add(c => c.ActionName, "update");

		var dialogOption = new DialogOptions() { FullWidth = true };
		var diablog = await DialogService.ShowAsync<EditProductDialog>("Sửa", parameters, dialogOption);
		var result = await diablog.Result;

		if (!result.Canceled)
		{
			await LoadData();
		}
	}

	private async Task AddProduct()
	{
		var parameters = new DialogParameters<EditProductDialog>();
		parameters.Add(c => c.ActionName, "add");

		var dialogOption = new DialogOptions() { FullWidth = true };
		var diablog = await DialogService.ShowAsync<EditProductDialog>("Thêm mới", parameters, dialogOption);
		var result = await diablog.Result;

		if (!result.Canceled)
		{
			await LoadData();
		}
	}

	private void ViewProductDetail(Guid productId)
	{
		var parameter = new DialogParameters<ProductItemDialog>();
		var options = new DialogOptions() { FullWidth = true};
		parameter.Add(c => c.ProductId, productId);
		DialogService.ShowAsync<ProductItemDialog>("adsad", parameter, options);
	}
}