using Microsoft.AspNetCore.Components;
using MudBlazor;
using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.ViewModelClient;


namespace ShoppingOnline.Admin.Pages.CategoryTask;

public partial class CategoryDetail
{

	[Parameter] public Guid CategoryId { get; set; }
	[Inject]
	public ICategoryClientService _CategoryClientService { get; set; }
	public CategoryVM _CategoryVM { get; set; } = new CategoryVM();

	protected override async Task OnInitializedAsync()
	{
		_CategoryVM = await _CategoryClientService.GetAllById(CategoryId);
	}
}
