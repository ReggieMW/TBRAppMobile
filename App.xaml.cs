using TBRAppMobile.Pages;
using TBRAppMobile.Services;

namespace TBRAppMobile;

public partial class App : Application
{

    public static BookService BookService { get; } = new BookService(); //makes BookService globally accessible 
    private static BookDatabase? _database;

    public static BookDatabase Database =>
        _database ??= new BookDatabase(Path.Combine(
            FileSystem.AppDataDirectory, "books.db3"));

    public App()
    {
        InitializeComponent();      //initializing UI
        MainPage = new AppShell();   //utilizing Shell Navigation
    }
}
