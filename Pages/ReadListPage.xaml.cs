using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TBRAppMobile.ViewModels;
using TBRAppMobile.Models;
using TBRAppMobile.Services;
using TBRAppMobile.Views;

namespace TBRAppMobile.Pages;

public partial class ReadListPage : ContentPage
{
    private readonly BookService _bookService;
    private BookListController? _controller;
    private bool _suppressNextNavigate;

    public ReadListPage()
    {
        InitializeComponent();
        _bookService = App.BookService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _controller ??= new BookListController(
            _bookService,
            () => _bookService.GetReadBooks(), // <-- Read list source
            BookList,
            SortPicker,
            AscSwitch,
            SearchEntry);

        _controller.Refresh();
    }

    private void OnChipClicked(object sender, ChipClickedEventArgs e)
    {
        _suppressNextNavigate = true;

        if (_controller is null) return;

        switch (e.Type)
        {
            case "Subject": _controller.SetSubjectOnly(e.Value); break;
            case "Vibe":    _controller.SetVibeOnly(e.Value);    break;
            case "Author":  _controller.SetAuthorOnly(e.Value);  break;
            case "Country": _controller.SetCountryOnly(e.Value); break;
            case "Source":  _controller.SetSourceOnly(e.Value);  break;
            case "Year":
                if (int.TryParse(e.Value, out var y)) _controller.SetExactYearOnly(y);
                break;
        }
        BookList.SelectedItem = null;
    }

    private void OnSortDirTapped(object? sender, EventArgs e)
    {
        // Flip the hidden switch; controller will pick this up via Toggled and Refresh()
        AscSwitch.IsToggled = !AscSwitch.IsToggled;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _controller?.Dispose(); // Unwire events cleanly
        _controller = null;
    }

    // Tap anywhere on the card to navigate to BookViewPage
    private async void OnCardTapped(object sender, TappedEventArgs e)
    {
        if (_suppressNextNavigate)
        {
            _suppressNextNavigate = false;
            return;
        }

        if (e.Parameter is Book book)
            await NavigationService.NavigateToBookViewPage(book.Id);
    }

    private void OnClearFiltersClicked(object sender, EventArgs e)
    {
        _controller?.ClearFilters();  // resets Search + all chip filters and refreshes
        BookList.SelectedItem = null;
    }
}
