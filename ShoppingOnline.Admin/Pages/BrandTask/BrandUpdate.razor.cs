using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.ViewModelClient;

namespace ShoppingOnline.Admin.Pages.BrandTask;

public partial class BrandUpdate
{

	[Parameter] public Guid id { get; set; }
	[Inject] public IBrandClientService _brandClientService { get; set; }
	public BrandVM _brandVM { get; set; } = new BrandVM();
	[Inject]
	NavigationManager _navigationManager { get; set; }
	protected override async Task OnInitializedAsync()
	{
		var rs = await _brandClientService.GetAllBrandClientById(id);
		_brandVM.Id = id;
		_brandVM.Name = rs.Name;
		_brandVM.Status = rs.Status;
		_brandVM.CreateBy = rs.CreateBy;

	}

	public async Task SubmitBrandUpdate(EditContext context)
	{
		var result = await _brandClientService.UpdateBrandClient(_brandVM);
		if (result)
		{
			_navigationManager.NavigateTo("/brands");
		}
	}
}
