using Projects;

IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

//builder.AddProject<Sample01_Blazor_MAUI_Hybrid_Web_Bootstrap_Web>("app-web-bootstrap");
builder.AddProject<Sample_Blazor_MAUI_Hybrid_Web_FluentUI_Web>("app-web-fluentui");
builder.AddProject<Sample_Blazor_MAUI_Hybrid_Web_FluentUI_Web_WASM>("app-web-fluentui-wasm");

/*
    MAUI setup

builder.AddProject<Sample01_Blazor_MAUI_Hybrid_Web_Bootstrap>("app_web");
*/

builder.Build().Run();
