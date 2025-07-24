using Microsoft.Maui.Controls;
using TBRAppMobile.Models;
using TBRAppMobile.ViewModels;
using TBRAppMobile.Services;
using TBRAppMobile.Helpers;

namespace TBRAppMobile.Pages
{
    public partial class BookViewPage : ContentPage
    {

        private readonly BookService _bookService;

        public BookViewPage(Book selectedBook, BookService bookService)
        {
            _bookService = bookService;
            InitializeComponent();
            BindingContext = new BookViewModel(selectedBook, App.BookService);
        }

//marks book as added to canon or not in canon, animation code included
        private async void OnCanonButtonClicked(object sender, EventArgs e)
        {
            if (BindingContext is BookViewModel vm)
            {
                // Animate background flash
                await CanonButton.ColorTo(Colors.Transparent, Colors.LightGreen, c => CanonButton.BackgroundColor = c, 100);
                await CanonButton.ColorTo(Colors.LightGreen, Colors.Transparent, c => CanonButton.BackgroundColor = c, 300);
                // Button Bump Animation
                await CanonButton.ScaleTo(1.1, 100, Easing.CubicOut);
                await CanonButton.ScaleTo(1.0, 100, Easing.CubicIn);

                vm.ToggleCanonCommand.Execute(null);
            }
        }

    }


}



