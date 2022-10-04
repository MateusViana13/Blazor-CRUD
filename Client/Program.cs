global using CRUD_WEBAPI_BLAZOR.Client.Services.CarService;
using CRUD_WEBAPI_BLAZOR.Client;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
