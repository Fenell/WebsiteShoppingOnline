using Microsoft.AspNetCore.Components;
using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.ViewModelClient;
using static MudBlazor.CategoryTypes;
using System.Net.Http;
using System;

namespace ShoppingOnline.Admin.Pages;

public partial class Brand 
{

	private bool _hidePosition;
	private bool _loading;
	[Inject]
	NavigationManager navigation { get; set; }	
	[Inject]
	private IBrandClientService _BrandClientService { get; set; }
	private List<BrandVM> _brandVM { get; set; } = new List<BrandVM>();


	protected override async Task OnInitializedAsync()
	{
		_brandVM = await _BrandClientService.GetAllBrandClient();
		StateHasChanged();
	}

	public async Task<bool> DeleteBrands(Guid id)
	{
		var rs =  await _BrandClientService.DeleteBrandClient(id);
		if (rs)
		{
			OnInitializedAsync();
			return true;
			
		}
		return false;
	}


}
