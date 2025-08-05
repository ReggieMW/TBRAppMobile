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
    private readonly NavigationService _navigationService;

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
        _bookService = App.BookService;
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
                BindingContext = new BookViewModel(book, _bookService, _navigationService);
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
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        BindingContext = null;
        _bookId = 0;
        _isLoaded = false;
    }
}
