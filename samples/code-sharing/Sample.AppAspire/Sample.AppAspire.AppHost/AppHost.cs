using Projects;
// using HolisticWare.Aspire.Hosting.Maui;

// HolisticWare.Tools.Devices.Android.Emulator.Launch("nexus_9_api_33");
// HolisticWare.Tools.Devices.Android.Emulator.Launch("emulator-android-34-google-apis-arm-v8a-pixel");


IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

//builder.AddProject<Sample01_Blazor_MAUI_Hybrid_Web_Bootstrap_Web>("app-web-bootstrap");
builder.AddProject<Sample_Blazor_MAUI_Hybrid_Web_FluentUI_Web>("app-web-fluentui");
builder.AddProject<Sample_Blazor_MAUI_Hybrid_Web_FluentUI_Web_WASM>("app-web-fluentui-wasm");
builder.AddProject<Sample_Blazor_MAUI_Hybrid_Web_FluentUI_Web_WASM_PWA>("app-web-fluentui-wasm-pwa");

/*
    MAUI setup
*/

/*
string project_maui = @"..\\ClientAppsIntegration.MAUI\\ClientAppsIntegration.MAUI.csproj";

builder
	.AddProject
	(
		"frontend-client-maui",
		project_maui,
		// overload added just to avoid ambigious call and leave the method name as is
		// without this parameter - ambigious call
		new[]
		{
			"net8.0-android",
			"net8.0-ios",
			"net8.0-maccatalyst",
		}
	)
	//.WithReference(apiService)
	.BuildSettings();

builder
	.BuildClient
	(
		"net8.0-android",
		"emulator-android-34-google-apis-arm-v8a-pixel"
	)
	// Launching 2 emulators does not work yet
	.BuildClient
	      (
	         "net8.0-android",
	         "Nexus_9_API_33"     // tablet
	         2                    // default = 1
	      )
	.BuildClient
	(
		"net8.0-ios",
		"017184FB-06E4-4C88-9662-13C1E2444486",
		2
	)
	.BuildClient
	(
		"net8.0-ios",
		"43A58A15-E4EA-4FDD-9DBD-5E8C16CBAF98"  // iPad
	)
	.BuildClient("maccatalyst")
	;
*/

builder
	// intercepting Build() to build/launch MAUI clients defined above
	.Build()
	// .BuildDistributedAppWithClientsMAUI()
	.Run();
