using Microsoft.Maui.Controls;
using TBRAppMobile.Models;
using TBRAppMobile.ViewModels;
using TBRAppMobile.Services;
using TBRAppMobile.Helpers;
using System.Diagnostics;

namespace TBRAppMobile.Pages;

[QueryProperty(nameof(BookId), "bookId")]
public partial class BookViewPage : ContentPage
{
    private readonly BookService _bookService;

    private int _bookId;
    private bool _isLoaded = false;

    public string BookId
    {
        get => _bookId.ToString();
        set
        {
            if (int.TryParse(value, out int id))
                _bookId = id;
            LoadBook();
        }
    }


    public BookViewPage()
    {
        InitializeComponent();
        _bookService = App.BookService!;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (!_isLoaded)
        {
            _isLoaded = true;
        }
    }

    private void LoadBook()
    {
        try
        {
            var book = _bookService.GetBookById(_bookId);
            if (book != null)
            {
                Debug.WriteLine($"[BookViewPage] Loaded book: {book.Title}");
                BindingContext = new BookViewModel(book, _bookService);
            }
            else
            {
                Debug.WriteLine($"[BookViewPage] Book not found for ID: {_bookId}");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[BookViewPage] Error loading book: {ex}");
        }
    }
    private async void OnCanonButtonClicked(object sender, EventArgs e)
    {
        if (BindingContext is BookViewModel vm)
        {
            if (CanonButton == null) return;
            await CanonButton.ColorTo(Colors.Transparent, Colors.LightGreen, c => CanonButton.BackgroundColor = c, 100);
            await CanonButton.ColorTo(Colors.LightGreen, Colors.Transparent, c => CanonButton.BackgroundColor = c, 300);
            await CanonButton.ScaleTo(1.1, 100, Easing.CubicOut);
            await CanonButton.ScaleTo(1.0, 100, Easing.CubicIn);

            vm.ToggleCanonCommand.Execute(null);
        }
    }

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        if (BindingContext is not BookViewModel vm) return;


        bool confirm = await DisplayAlert("Confirm Delete Book", $"Are you sure you want to delete '{vm.Title}'?", "Yes", "Cancel");

        if (!confirm) return;

        var targetRoute = vm.Status switch
        {
            BookStatus.TBR => "//TBRListPage",
            BookStatus.CurrentReads => "//CurrentReadsPage",
            BookStatus.Read => "//ReadListPage",
            BookStatus.DNF => "//DNFPage",
            _ => "//TBRListPage"
        };

        try
        {
            if (sender is Button btn) btn.IsEnabled = false;
            await _bookService.DeleteBook(vm.Book);
            await Shell.Current.GoToAsync($"{targetRoute}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[Delete Error] {ex.Message}");
            await DisplayAlert("Error", "Could not delete the book.", "OK");
        }
        finally
        {
            if (sender is Button bbtn) bbtn.IsEnabled = true;
        }


    }
}
