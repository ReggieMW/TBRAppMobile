using Microsoft.Maui.Controls;
using TBRAppMobile.Models;
using TBRAppMobile.ViewModels;
using TBRAppMobile.Services;
using TBRAppMobile.Helpers;

namespace TBRAppMobile.Pages
{
    public partial class BookViewPage : ContentPage
    {
        public BookViewPage(Book selectedBook, BookService bookService)
        {
            InitializeComponent();
            BindingContext = new BookViewModel(selectedBook, bookService);
        }

        private async void OnCanonButtonClicked(object sender, EventArgs e)
        {
            if (BindingContext is BookViewModel vm)
            {
                // Animate background flash
                await CanonButton.ColorTo(Colors.Transparent, Colors.LightGreen, c => CanonButton.BackgroundColor = c, 100);
                await CanonButton.ColorTo(Colors.LightGreen, Colors.Transparent, c => CanonButton.BackgroundColor = c, 300);

                await CanonButton.ScaleTo(1.1, 100, Easing.CubicOut);
                await CanonButton.ScaleTo(1.0, 100, Easing.CubicIn);
                
                vm.ToggleCanonCommand.Execute(null);
            }
        }

    }


}



