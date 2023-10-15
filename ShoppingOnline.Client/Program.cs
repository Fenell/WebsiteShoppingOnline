using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using ShoppingOnline.Client;
using ShoppingOnline.Client.Services.ColorClient;
using ShoppingOnline.Client.Services.OrderClient;
using ShoppingOnline.Client.Services.ProductClient;
using ShoppingOnline.Client.Services.ProductItemClient;
using ShoppingOnline.Client.Services.SizeClient;
using ShoppingOnline.Client.Provider;
using ShoppingOnline.Client.Services.Implement;
using ShoppingOnline.Client.Services.Interface;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

var apiUrl = builder.Configuration.GetValue<string>("BaseApiUrl");
builder.Services.AddScoped(c => new HttpClient() { BaseAddress = new Uri(apiUrl) });

//DI
builder.Services.AddScoped<IProductClientServices, ProductClientServices>();
builder.Services.AddScoped<ISizeClientServices, SizeClientServices>();
builder.Services.AddScoped<IColorClientServices, ColorClientServices>();
builder.Services.AddScoped<IProductItemClientServices, ProductItemClientServices>();
builder.Services.AddScoped<IOrderClientServices, OrderClientServices>();


//LocalStorage
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();

