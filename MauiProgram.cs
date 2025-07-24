using Microsoft.Extensions.Logging;
using TBRAppMobile.Pages;
using TBRAppMobile.Services;

namespace TBRAppMobile;

//initializing/building MAUI
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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });


#if DEBUG
        builder.Logging.AddDebug();
#endif

        // Register services as Singletons (static)
        builder.Services.AddSingleton<BookService>();

        // Register pages as Transients (dynamic)
        builder.Services.AddTransient<AddBookPage>();
        builder.Services.AddTransient<TBRListPage>();
        builder.Services.AddTransient<ReadListPage>();
        builder.Services.AddTransient<CurrentReadsPage>();
        builder.Services.AddTransient<DNFPage>();
        builder.Services.AddTransient<MyCanonPage>();
        builder.Services.AddTransient<BookViewPage>();

        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddSingleton<App>();

        var mauiApp = builder.Build();

        return mauiApp;
    }
}

