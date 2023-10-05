using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using ShoppingOnline.Client;
using ShoppingOnline.Client.Services.ColorClient;
using ShoppingOnline.Client.Services.ProductClient;
using ShoppingOnline.Client.Services.SizeClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

//DI
builder.Services.AddScoped<IProductClientServices, ProductClientServices>();
builder.Services.AddScoped<ISizeClientServices, SizeClientServices>();
builder.Services.AddScoped<IColorClientServices, ColorClientServices>();


//LocalStorage
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();

