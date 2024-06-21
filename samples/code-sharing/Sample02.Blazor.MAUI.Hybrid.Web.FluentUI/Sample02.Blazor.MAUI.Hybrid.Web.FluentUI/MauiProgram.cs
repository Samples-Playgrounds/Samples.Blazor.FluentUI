using Microsoft.Extensions.Logging;
using Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Shared.Services;
using Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Services;

namespace Sample02.Blazor.MAUI.Hybrid.Web.FluentUI;

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
        builder.Services.AddSingleton<IFormFactor, FormFactor>();

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
