using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using Sample.Blazor.MAUI.Hybrid.Web.FluentUI.Shared.Services;
using Sample.Blazor.MAUI.Hybrid.Web.FluentUI.Web.WASM.PWA;
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

/*
CORS - Server side concept (makes no sense on client side)

builder.Services.AddCors
					(
						options =>
						{
							options.AddPolicy
							(
								"cors-wasm",
								builder =>
								{
									builder
										.AllowAnyOrigin()
										.AllowAnyHeader()
										.AllowAnyMethod()
										.SetIsOriginAllowedToAllowWildcardSubdomains();
								}
							);
						}
					);
*/

builder.Services.AddHttpClient();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddFluentUIComponents();

// Add device-specific services used by the Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Shared project
builder.Services.AddSingleton<ISystemInformation, SystemInformation>();



WebAssemblyHost? app = builder.Build();

//app.UseCors("cors-wasm");

// app
//.MapRazorComponents<App>()
//.AddAdditionalAssemblies(typeof(Sample.Blazor.MAUI.Hybrid.Web.FluentUI.Shared._Imports).Assembly);

await app.RunAsync();
