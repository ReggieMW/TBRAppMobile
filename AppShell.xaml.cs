using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using TBRAppMobile.Pages;
using System.Diagnostics;

namespace TBRAppMobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        // Register page routes
        Routing.RegisterRoute(nameof(AddBookPage), typeof(AddBookPage));
        Routing.RegisterRoute(nameof(BookViewPage), typeof(BookViewPage));
        
    }
}