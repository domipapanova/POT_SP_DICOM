using Frontend;
using Frontend.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//added connection to web api
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7148/") });

builder.Services.AddScoped<IDoctorService, DoctorService>();
await builder.Build().RunAsync();
