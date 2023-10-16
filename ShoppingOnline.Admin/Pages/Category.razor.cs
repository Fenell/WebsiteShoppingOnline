using Microsoft.AspNetCore.Components;
using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.ViewModelClient;

namespace ShoppingOnline.Admin.Pages;

public partial class Category
{

	private bool _hidePosition;
	private bool _loading;
	[Inject]
	NavigationManager navigation { get; set; }
	[Inject]
	private ICategoryClientService _CategoryClientService { get; set; }
	private List<CategoryVM> _categoryVM { get; set; } = new List<CategoryVM>();

	protected override async Task OnInitializedAsync()
	{
		_categoryVM = await _CategoryClientService.GetAll();
		StateHasChanged();
	}

	public async Task<bool> DeleteCategorys(Guid id)
	{
		var rs = await _CategoryClientService.DeleteCategory(id);
		if (rs)
		{
			OnInitializedAsync();
			return true;

		}
		return false;
	}


}
