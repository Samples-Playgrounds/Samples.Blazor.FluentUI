using Microsoft.Extensions.Logging;
using Sample01.Blazor.MAUI.Hybrid.Web.Bootstrap.Shared.Services;
using Sample01.Blazor.MAUI.Hybrid.Web.Bootstrap.Services;

namespace Sample01.Blazor.MAUI.Hybrid.Web.Bootstrap;

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

        // Add device-specific services used by the Sample01.Blazor.MAUI.Hybrid.Web.Bootstrap.Shared project
        builder.Services.AddSingleton<IFormFactor, FormFactor>();

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
