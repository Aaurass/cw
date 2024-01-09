using Microsoft.Extensions.Logging;
using cw.Data;
using QuestPDF.Infrastructure;

namespace cw;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        QuestPDF.Settings.License = LicenseType.Community;
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<OrderService>();
        return builder.Build();
    }
}

