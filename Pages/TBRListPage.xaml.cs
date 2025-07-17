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

#if DEBUG
        bookService.SeedTestBooks();
#endif

        BindingContext = _bookService;

        Debug.WriteLine($"Loaded {_bookService.TBRBooks.Count} books.");
    }

    private void OnStatusChanged(object? sender, Book book)
    {

    }


    private void OnRemoveRequested(object? sender, Book book)
    {
        _bookService.RemoveBook(book);
    }


    private async void OnMarkAsReadClicked(object sender, EventArgs e)
    {
        var book = (sender as Button)?.BindingContext as Book;
        if (book == null) return;

        bool updateVibe = await DisplayAlert("Update Vibe?", "Do you want to update the vibe?", "Yes", "No");
        string? newVibe = null;
        if (updateVibe)
            newVibe = await DisplayPromptAsync("New Vibe", "Enter the book's new vibe:");

        bool recommend = await DisplayAlert("Recommend?", "Did you like this book enough to recommend it?", "Yes", "No");
        string? comparable = null;
        if (recommend)
            comparable = await DisplayPromptAsync("Comparable", "Enter a comparable author or book:");

        _bookService.MarkAsRead(book, newVibe, comparable);
        _bookService.UpdateBookStatus(book, BookStatus.Read);

        await DisplayAlert("Done", $"{book!.Title} marked as read.", "OK");
    }

    private async void OnAddBookClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddBookPage));
    }


    private void OnBookCardCreated(object? sender, EventArgs e)
    {
        if (sender is BookCard card)
        {
            card.StatusChanged += OnStatusChanged;
            card.RemoveRequested += OnRemoveRequested;
        }
    }

}
