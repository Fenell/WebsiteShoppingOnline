using Microsoft.AspNetCore.Components;
using MudBlazor;
using ShoppingOnline.Admin.Models.Auth;
using ShoppingOnline.Admin.Services.Interface;

namespace ShoppingOnline.Admin.Pages.Authentication;

public partial class Login
{
	[Inject]
	public IAuthService AuthService { get; set; }
	[Inject] public IDialogService DialogService { get; set; }
	[Inject]
	public NavigationManager NavigationManager { get; set; }

	public SignInVM SignInVm { get; set; } = new();

	public bool IsProcessing { get; set; }

	protected override void OnInitialized()
	{
		IsProcessing = true;
		IsProcessing = false;
	}

	private async Task LoginClick(SignInVM signInVm)
	{
		var optionDialog = new DialogOptions() { CloseOnEscapeKey = true};
		DialogService.Show<LoadingDialog>("Đang đăng nhập", optionDialog);
		var result = await AuthService.Login(signInVm);

		if (result)
		{
			NavigationManager.NavigateTo("/");
		}
	}
}