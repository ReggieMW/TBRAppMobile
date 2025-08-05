using Microsoft.Maui.Controls;
using System.Diagnostics;
using TBRAppMobile.Models;
using TBRAppMobile.Services;

namespace TBRAppMobile.Pages
{
    public partial class ReadListPage : ContentPage
    {
        private readonly BookService _bookService;

        //updates page with most current version of List on page load
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = _bookService;
            BookList.ItemsSource = _bookService.GetReadBooks();
        }

        public ReadListPage(BookService bookService)
        {
            InitializeComponent();
            _bookService = bookService;
            BindingContext = _bookService;
            BookList.ItemsSource = _bookService.ReadBooks;
        }

        //Allows user to click a book and navigate to BookViewPage
        private async void OnBookSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Book selectedBook)
            {
                ((CollectionView)sender).SelectedItem = null;

                await Shell.Current.GoToAsync($"{nameof(BookViewPage)}?bookId={selectedBook.Id}");
            }
        }
        
        protected override void OnDisappearing()
{
    base.OnDisappearing();
    BindingContext = null;
}


    }
}