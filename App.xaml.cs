using System.IO;
using Microsoft.Maui.Storage;
using TBRAppMobile.Services;

namespace TBRAppMobile;

public partial class App : Application
{
    public static BookDatabase Database { get; private set; } = null!;
    public static BookService  BookService { get; private set; } = null!;
    public static GoogleBooksService GoogleBooksService { get; private set; } = null!;


    public App()
    {
        InitializeComponent();

        try
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "books.db3");
            Database = new BookDatabase(dbPath);
            BookService = new BookService(Database);
            GoogleBooksService = new GoogleBooksService();

#if DEBUG
            BookService.SeedTestBooks();
#endif
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[App ctor] Startup error: {ex}");
            // Fail fast to reveal the exception in Output:
            throw;
        }
        AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            System.Diagnostics.Debug.WriteLine($"[UnhandledException] {e.ExceptionObject}");

        TaskScheduler.UnobservedTaskException += (s, e) =>
        {
            System.Diagnostics.Debug.WriteLine($"[UnobservedTaskException] {e.Exception}");
            e.SetObserved();
        };

        MainPage = new AppShell();
    }
}
