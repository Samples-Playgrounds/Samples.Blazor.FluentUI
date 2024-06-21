using Projects;

IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Sample01_Blazor_MAUI_Hybrid_Web_Bootstrap_Web>("app-web");

/*
    MAUI setup

builder.AddProject<Sample01_Blazor_MAUI_Hybrid_Web_Bootstrap>("app_web");
*/

builder.Build().Run();
