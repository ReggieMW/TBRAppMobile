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
    
    //updates page with most current version of List on page load
    protected override void OnAppearing()
    {
        base.OnAppearing();
        BindingContext = _bookService;
        BookList.ItemsSource = _bookService.GetTBR_Books();
    }

    public TBRListPage(BookService bookService)
    {
        InitializeComponent();
        _bookService = bookService;
        BindingContext = _bookService;
        BookList.ItemsSource = _bookService.TBRBooks;

#if DEBUG
        bookService.SeedTestBooks();
#endif


        Debug.WriteLine($"Loaded {_bookService.TBRBooks.Count} books.");
    }

    //Allows user to click a book and navigate to BookViewPage
    private async void OnBookSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Book selectedBook)
        {
            await Navigation.PushAsync(new BookViewPage(selectedBook, App.BookService));
        }

    ((CollectionView)sender).SelectedItem = null; // clear selection
    }
}
