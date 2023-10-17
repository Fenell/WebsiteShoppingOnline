using Microsoft.AspNetCore.Components;
using MudBlazor;
using ShoppingOnline.Admin.Models.ProductItem;
using ShoppingOnline.Admin.Services.Interface;

namespace ShoppingOnline.Admin.Pages.ProductItem;

public partial class ProductItemDialog
{
	[Inject] public IProductItemService ProductItemService { get; set; }
	[Inject] public ISnackbar Snackbar { get; set; }
	[Inject] public IDialogService DialogService { get; set; }
	[CascadingParameter] MudDialogInstance MudDialog { get; set; }
	[Parameter] public Guid ProductId { get; set; }
	public List<ProductItemVM> ListProductItems { get; set; } = new();

	public bool IsProcessing { get; set; }

	protected override async Task OnInitializedAsync()
	{
		IsProcessing = true;
		await LoadData();
		IsProcessing = false;
	}

	private async Task LoadData()
	{
		ListProductItems = await ProductItemService.GetProductItemsWithProductId(ProductId);
		StateHasChanged();
	}

	void Submit() => MudDialog.Close(DialogResult.Ok(true));
	void Cancel() => MudDialog.Cancel();


	private async Task ViewProductItemDetail(Guid productItemId)
	{
		var parameters = new DialogParameters<ProductItemDetailDialog>();
		var options = new DialogOptions() { FullWidth = true };
		parameters.Add(c => c.ProductItemId, productItemId);
		parameters.Add(c => c.ProductId, ProductId);
		var dialog = await DialogService.ShowAsync<ProductItemDetailDialog>("Chi tiết biến thể", parameters, options);
		var result = await dialog.Result;

		if (!result.Canceled)
			await LoadData();
	}

	private async Task AddProductItem(Guid productId)
	{
		var parameters = new DialogParameters<ProductItemDetailDialog>();
		var options = new DialogOptions() { FullWidth = true };
		parameters.Add(c => c.ProductId, productId);
		var dialog = await DialogService.ShowAsync<ProductItemDetailDialog>("Tạo mới", parameters, options);
		var result = await dialog.Result;

		if (!result.Canceled)
			await LoadData();
	}
}