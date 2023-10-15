using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using ShoppingOnline.Admin;
using ShoppingOnline.Admin.Pages;
using ShoppingOnline.Admin.Provider;
using ShoppingOnline.Admin.Services.Implement;
using ShoppingOnline.Admin.Services.Interface;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
// Add services to the container.

//builder.Services.AddSingleton<Brand>();

builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

builder.Services.AddTransient<IAuthService, AuthService>();

builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IBrandClientService, BrandClientService>();
builder.Services.AddScoped<ICategoryClientService, CategoryClientService>();

var apiUrl = builder.Configuration.GetValue<string>("BaseApiUrl");
builder.Services.AddScoped(c => new HttpClient() { BaseAddress = new Uri(apiUrl) });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
await builder.Build().RunAsync();

