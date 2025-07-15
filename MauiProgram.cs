using Microsoft.Extensions.Logging;
using TBRAppMobile.Pages;
using TBRAppMobile.Services;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif

	    builder.Services.AddSingleton<BookService>();
		builder.Services.AddSingleton<ListManager>();
		builder.Services.AddTransient<AddBookPage>();
		builder.Services.AddTransient<TBRListPage>();
		builder.Services.AddSingleton<ReadListPage>();
		builder.Services.AddSingleton<CanonPage>();

		return builder.Build();
	}
}
