using TBRAppMobile.Models;
using System.Diagnostics;
using System.Collections.ObjectModel;
using TBRAppMobile.Services;
using TBRAppMobile.ViewModels;
using TBRAppMobile.Pages;

namespace TBRAppMobile.Services;

//class handles functionality of book properties
public static class NavigationService
{
    public static async Task NavigateToPageAsync(string pageName)
    {
        await Shell.Current.GoToAsync($"//{pageName}");
    }

    public static async Task NavigateToBookViewPage(int bookId)
    {
        await Shell.Current.GoToAsync($"{nameof(BookViewPage)}?bookId={bookId}");
    }
}
