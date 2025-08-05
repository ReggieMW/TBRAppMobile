using Microsoft.Maui.Controls;
using System.Diagnostics;
using TBRAppMobile.Models;
using TBRAppMobile.Services;

namespace TBRAppMobile.Pages
{
    public partial class CurrentReadsPage : ContentPage
    {
        private readonly BookService _bookService;

        public CurrentReadsPage(BookService bookService)
        {
            InitializeComponent();
            _bookService = bookService;

#if DEBUG
            _bookService.SeedTestBooks();
#endif

        }

        protected override void OnAppearing()
        {
            BindingContext = _bookService;
            base.OnAppearing();
            BookList.ItemsSource = _bookService.GetCurrentReads();
        }

        private async void OnBookSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Book selectedBook)
            {
                ((CollectionView)sender).SelectedItem = null;
                await Shell.Current.GoToAsync($"{nameof(BookViewPage)}?bookId={selectedBook.Id}");
            }
        }
    }

}