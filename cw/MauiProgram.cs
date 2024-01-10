using Microsoft.Extensions.Logging;
using cw.Data;

namespace cw
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
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

            builder.Services.AddSingleton<MemberService>();
            builder.Services.AddSingleton<OrderService>();
            return builder.Build();
        }
    }
}