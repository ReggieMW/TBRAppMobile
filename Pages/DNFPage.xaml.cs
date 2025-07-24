using Microsoft.Maui.Controls;
using System.Diagnostics;
using TBRAppMobile.Models;
using TBRAppMobile.Services;

namespace TBRAppMobile.Pages
{
    public partial class DNFPage : ContentPage
    {
        private readonly BookService _bookService;

        //updates page with most current version of List on page load
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = _bookService;
            BookList.ItemsSource = _bookService.GetDNFBooks();
        }

        public DNFPage(BookService bookService)
        {
            InitializeComponent();
            _bookService = bookService;
            BindingContext = _bookService;
            BookList.ItemsSource = _bookService.DNFBooks;

        }

//Allows user to click a book and navigate to BookViewPage
        private async void OnBookSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Book selectedBook)
                await Navigation.PushAsync(new BookViewPage(selectedBook, App.BookService));

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}