using Microsoft.Extensions.Logging;

using Microsoft.FluentUI.AspNetCore.Components;

using Sample.Blazor.MAUI.Hybrid.Web.FluentUI.Shared.Services;
using Sample.Blazor.MAUI.Hybrid.Web.FluentUI.MAUI.Services;

namespace Sample.Blazor.MAUI.Hybrid.Web.FluentUI.MAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        // Add device-specific services used by the Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Shared project
        builder.Services.AddSingleton<ISystemInformation, SystemInformation>();

        builder.Services.AddMauiBlazorWebView();

        #if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
        #endif

        builder.Services.AddHttpClient();
        builder.Services.AddFluentUIComponents();


        return builder.Build();
    }
}
