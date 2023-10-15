using Microsoft.AspNetCore.Components;
using ShoppingOnline.Admin.Services.Interface;
using ShoppingOnline.Admin.ViewModels.Models;

namespace ShoppingOnline.Admin.Pages;

public partial class Colors
{
	[Inject] private IColorService _colorService { get; set; }
	private List<ColorsVM> colorsVMs;
	protected override async Task OnInitializedAsync()
	{
		colorsVMs = await _colorService.GetAllColors();
		StateHasChanged();
	}

	public async Task<bool> OnDeleteColor(Guid id) 
	{
		await _colorService.DeleteColor(id);
		await OnInitializedAsync();
		return true;
	}


}
