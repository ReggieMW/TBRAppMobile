using Microsoft.Extensions.Logging;
using TBRAppMobile.Pages;
using TBRAppMobile.Services;
using Microsoft.Maui.LifecycleEvents;

#if WINDOWS
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

namespace TBRAppMobile;

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

builder.ConfigureLifecycleEvents(events =>
        {
#if WINDOWS
            events.AddWindows(w =>
            {
                w.OnWindowCreated(window =>
                {
                    const int width  = 950;
                    const int height = 1260;

                    var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
                    var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hwnd);
                    var appWindow = AppWindow.GetFromWindowId(windowId);

                    // Optional: tweak chrome/behavior
                    if (appWindow.Presenter is OverlappedPresenter p)
                    {
                        p.IsMaximizable = false;   // keep it small
                        // p.IsResizable = false;  // uncomment to lock size
                    }

                    appWindow.Resize(new SizeInt32(width, height));
                    // Optional: position the window
                    // appWindow.Move(new PointInt32(100, 100));
                });
            });
#endif
        });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // Register services as Singletons (static)
        builder.Services.AddSingleton<BookService>();
        builder.Services.AddSingleton<GoogleBooksService>();


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

