using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TBRAppMobile.ViewModels;
using TBRAppMobile.Models;
using TBRAppMobile.Services;
using TBRAppMobile.Views;

namespace TBRAppMobile.Pages;

public partial class TBRListPage : ContentPage
{
    private readonly BookService _bookService;
    private BookListController? _controller; 
    

    public TBRListPage()
    {
        InitializeComponent();
        _bookService = App.BookService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _controller ??= new BookListController(
            _bookService,
            () => _bookService.GetTBR_Books(),     
            BookList,
            SortPicker,
            AscSwitch,
            SearchEntry);

        _controller.Refresh();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _controller?.Dispose(); // Unwire events cleanly
        _controller = null;
    }

    //Allows user to click a book and navigate to BookViewPage
    private async void OnBookSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Book selectedBook)
        {
            ((CollectionView)sender).SelectedItem = null;

            await NavigationService.NavigateToBookViewPage(selectedBook.Id);

        }
    }
}
