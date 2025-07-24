using TBRAppMobile.Pages;
using TBRAppMobile.Services;

namespace TBRAppMobile;

public partial class App : Application
{

    public static BookService BookService { get; } = new BookService(); //makes BookService globally accessible 

    public App()
    {
        InitializeComponent();      //initializing UI
        MainPage = new AppShell();   //utilizing Shell Navigation
    }
}
