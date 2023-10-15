using Microsoft.AspNetCore.Components;
using MudBlazor;
using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.ViewModelClient;

namespace ShoppingOnline.Admin.Pages.BrandTask;

public partial class BrandDetail
{
	[Parameter] public Guid BrandId { get; set; }
	[Inject]
	public IBrandClientService _BrandClientService { get; set; }
	public BrandVM _BrandVM { get; set; } = new BrandVM() ;

	protected override async Task OnInitializedAsync()
	{
		_BrandVM = await _BrandClientService.GetAllBrandClientById(BrandId);
	}
}
