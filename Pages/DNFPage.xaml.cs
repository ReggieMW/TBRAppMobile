using Microsoft.Maui.Controls;
using TBRAppMobile.Models;
using TBRAppMobile.Services;

namespace TBRAppMobile.Pages
{
    public partial class DNFPage : ContentPage
    {
        private readonly BookService _bookService;
        private BookListController? _controller;

        public DNFPage()
        {
            InitializeComponent();
            _bookService = App.BookService;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _controller ??= new BookListController(
                _bookService,
                () => _bookService.GetDNFBooks(),
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

        private async void OnBookSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Book selectedBook)
            {
                ((CollectionView)sender).SelectedItem = null;
                await NavigationService.NavigateToBookViewPage(selectedBook.Id);
            }
        }
    }
}
