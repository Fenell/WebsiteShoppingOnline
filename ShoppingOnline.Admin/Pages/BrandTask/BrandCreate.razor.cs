using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.ViewModelClient;

namespace ShoppingOnline.Admin.Pages.BrandTask;

public partial class BrandCreate
{
	BrandVM _brandVMclient { get; set; } = new BrandVM();
	[Inject]
	IBrandClientService _brandClientService { get; set; }
	[Inject]
	NavigationManager  _navigationManager { get; set; }

	public async Task SubmidBrandCreate(EditContext context)
	{
		var rs = await _brandClientService.CreateBrandClient(_brandVMclient);
		if (rs)
		{
			_navigationManager.NavigateTo("/brands");
		}
	}

}
