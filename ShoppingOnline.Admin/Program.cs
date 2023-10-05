using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using ShoppingOnline.Admin;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();


var apiUrl = builder.Configuration.GetValue<string>("BaseApiUrl");
builder.Services.AddScoped(c => new HttpClient() { BaseAddress = new Uri(apiUrl) });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
await builder.Build().RunAsync();
