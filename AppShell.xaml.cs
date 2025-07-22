using Microsoft.Maui.Controls;
using TBRAppMobile.Pages;


namespace TBRAppMobile;

public partial class AppShell : Shell
{

	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(TBRListPage), typeof(TBRListPage));
		Routing.RegisterRoute(nameof(AddBookPage), typeof(AddBookPage));
		Routing.RegisterRoute(nameof(BookViewPage), typeof(BookViewPage));
		Routing.RegisterRoute(nameof(ReadListPage), typeof(ReadListPage));
		Routing.RegisterRoute(nameof(CurrentReadsPage), typeof(CurrentReadsPage));
		Routing.RegisterRoute(nameof(DNFPage), typeof(DNFPage));
		Routing.RegisterRoute(nameof(MyCanonPage), typeof(MyCanonPage));

	}
}
