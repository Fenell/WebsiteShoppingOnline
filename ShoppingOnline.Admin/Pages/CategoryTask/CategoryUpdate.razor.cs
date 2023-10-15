using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.ViewModelClient;

namespace ShoppingOnline.Admin.Pages.CategoryTask;

public partial class CategoryUpdate
{
	[Parameter] public Guid id { get; set; }
	[Inject] public ICategoryClientService _categoryClientService { get; set; }
	public CategoryVM _categoryVM { get; set; } = new CategoryVM();
	[Inject]
	NavigationManager _navigationManager { get; set; }
	protected override async Task OnInitializedAsync()
	{
		var rs = await _categoryClientService.GetAllById(id);
		_categoryVM.Id = id;
		_categoryVM.Name = rs.Name;
		_categoryVM.SeoTitle = rs.SeoTitle;
		_categoryVM.Status = rs.Status;

	}

	public async Task SubmitCategoryUpdate(EditContext context)
	{
		var result = await _categoryClientService.UpdateCategory(_categoryVM);
		if (result)
		{
			_navigationManager.NavigateTo("/categorys");
		}
	}
}
