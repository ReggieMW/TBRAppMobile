using TBRAppMobile.Pages;
using TBRAppMobile.Services;

namespace TBRAppMobile;

public partial class App : Application
{
    public static BookService BookService { get; } = new BookService();

    public App()
    {
        InitializeComponent();
        MainPage = new AppShell(); 
    }
}
