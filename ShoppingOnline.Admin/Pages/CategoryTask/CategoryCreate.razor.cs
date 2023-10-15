using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ShoppingOnline.Admin.Services.Implement;
using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.ViewModelClient;
using static ShoppingOnline.Admin.Pages.CategoryTask.CategoryCreate;

namespace ShoppingOnline.Admin.Pages.CategoryTask;

public partial class CategoryCreate
{
	CategoryVM _CategoryVM { get; set; } = new CategoryVM();
	[Inject]
	ICategoryClientService _categoryClientService { get; set; }
	[Inject]
	NavigationManager _navigationManager { get; set; }

	public async Task SubmidBrandCreate(EditContext context)
	{
		var rs = await _categoryClientService.CreateCategory(_CategoryVM);
		if (rs)
		{
			_navigationManager.NavigateTo("/categorys");
		}
	}

}
