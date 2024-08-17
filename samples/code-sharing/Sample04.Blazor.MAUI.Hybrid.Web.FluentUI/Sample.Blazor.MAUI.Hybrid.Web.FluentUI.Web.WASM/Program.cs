using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

using Sample.Blazor.MAUI.Hybrid.Web.FluentUI.Web.WASM;
using Sample.Blazor.MAUI.Hybrid.Web.FluentUI.Shared.Services;
using Sample.Blazor.MAUI.Hybrid.Web.FluentUI.Web.WASM.Services;

Environment.SetEnvironmentVariable
					(
						"WEBVIEW2_ADDITIONAL_BROWSER_ARGUMENTS", 
						"--disable-features=AutoupgradeMixedContent"
						+
						"--unsafely-treat-insecure-origin-as-secure=http://192.168.0.1:7081"
					);

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder
											.CreateDefault(args)
											#if DEBUG
											// .UseSetting(WebHostDefaults.DetailedErrorsKey, "true")
											// .UseEnvironment(Environments.Development)
											#endif
											;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddFluentUIComponents();

// Add device-specific services used by the Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Shared project
builder.Services.AddSingleton<ISystemInformation, SystemInformation>();

// builder.Services.AddCors();

// app.Services
//     .AddCors(options =>
//     {
//         options.AddDefaultPolicy(builder =>
//         {
//             builder.AllowAnyMethod()
//                 .AllowAnyHeader()
//                 .SetIsOriginAllowed(origin => true) // allow any origin  
//                 .AllowCredentials();               // allow credentials 
//         });
//     });

WebAssemblyHost? app = builder.Build();

// app
    //.MapRazorComponents<App>()
    //.AddAdditionalAssemblies(typeof(Sample.Blazor.MAUI.Hybrid.Web.FluentUI.Shared._Imports).Assembly);

await app.RunAsync();
