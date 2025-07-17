using TBRAppMobile.Pages;

namespace TBRAppMobile;

public partial class App : Application
{
    public App(AppShell appShell)
    {
        InitializeComponent();

        MainPage = appShell; // Shell will now handle page navigation
    }
}
