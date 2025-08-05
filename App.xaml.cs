using TBRAppMobile.Pages;
using TBRAppMobile.Services;

namespace TBRAppMobile;

public partial class App : Application
{
    public static BookDatabase Database =>
        _database ??= new BookDatabase(Path.Combine(
            FileSystem.AppDataDirectory, "books.db3"));
    private static BookDatabase? _database;

    public static BookService? BookService { get; private set; }

    public App()
    {
        InitializeComponent();

        BookService = new BookService();

#if DEBUG
        BookService.SeedTestBooks();
#endif

        MainPage = new AppShell();
    }

}

