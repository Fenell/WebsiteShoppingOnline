using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using ShoppingOnline.Admin;
using ShoppingOnline.Admin.Constants;
using ShoppingOnline.Admin.Provider;
using ShoppingOnline.Admin.Services.Implement;
using ShoppingOnline.Admin.Services.Interface;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
// Add services to the container.


var apiUrl = builder.Configuration.GetValue<string>("BaseApiUrl");

builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

builder.Services.AddHttpClient(ApplicationConstant.ClientName, config =>
{
	config.BaseAddress = new Uri(apiUrl);
});

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductItemService, ProductItemService>();
builder.Services.AddScoped<IProductImageService,  ProductImageService>();

builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<ISizeService, SizeService>();

builder.Services.AddTransient<IAuthService, AuthService>();

builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IBrandClientService, BrandClientService>();
builder.Services.AddScoped<ICategoryClientService, CategoryClientService>();

builder.Services.AddScoped(c => new HttpClient() { BaseAddress = new Uri(apiUrl) });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
await builder.Build().RunAsync();

