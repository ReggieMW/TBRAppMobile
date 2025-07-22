using Microsoft.Maui.Controls;
using System.Diagnostics;
using TBRAppMobile.Models;
using TBRAppMobile.Services;

namespace TBRAppMobile.Pages
{
    public partial class MyCanonPage : ContentPage
    {
        private readonly BookService _bookService;

        public MyCanonPage(BookService bookService)
        {
            InitializeComponent();
            _bookService = bookService;
            BindingContext = _bookService;
            BookList.ItemsSource = _bookService.MyCanon;

            Debug.WriteLine($"Loaded {_bookService.MyCanon.Count} canon books.");
        }

        private async void OnBookSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Book selectedBook)
                await Navigation.PushAsync(new BookViewPage(selectedBook, App.BookService));

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}