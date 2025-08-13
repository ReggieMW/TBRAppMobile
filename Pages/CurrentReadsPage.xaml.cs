using Microsoft.Maui.Controls;
using TBRAppMobile.Models;
using TBRAppMobile.Services;

namespace TBRAppMobile.Pages
{
    public partial class CurrentReadsPage : ContentPage
    {
        private readonly BookService _bookService;
        private BookListController? _controller;

    
        public CurrentReadsPage()
        {
            InitializeComponent();
            _bookService = App.BookService;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // If BookListController expects a Func<ObservableCollection<Book>>,
            // pass a lambda. If it expects the collection directly, pass the collection.
            _controller ??= new BookListController(
                _bookService,
                () => _bookService.GetCurrentReads(),
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
