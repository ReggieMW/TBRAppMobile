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


    private void OnRemoveRequested(object? sender, Book book)
    {
        _bookService.RemoveBook(book);
    }

    private async void OnAddBookClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddBookPage));
    }
    private async void OnBookSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Book selectedBook)
        {
            await Navigation.PushAsync(new BookViewPage(selectedBook, App.BookService));
        }

    ((CollectionView)sender).SelectedItem = null; // clear selection
    }
}
