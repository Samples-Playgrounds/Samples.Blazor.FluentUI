using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;

using Sample.Blazor.MAUI.Hybrid.Web.FluentUI.Web.WASM;
using Sample.Blazor.MAUI.Hybrid.Web.FluentUI.Shared.Services;
using Sample.Blazor.MAUI.Hybrid.Web.FluentUI.Web.WASM.Services;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddFluentUIComponents();

// Add device-specific services used by the Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

WebAssemblyHost app = builder.Build();
// app
	//.MapRazorComponents<App>()
	//.AddAdditionalAssemblies(typeof(Sample.Blazor.MAUI.Hybrid.Web.FluentUI.Shared._Imports).Assembly);

await app.RunAsync();
