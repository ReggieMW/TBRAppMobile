using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System.Diagnostics;
using TBRAppMobile.Models;
using TBRAppMobile.Services;
using TBRAppMobile.ViewModels;

namespace TBRAppMobile.Pages
{
    public partial class AddBookPage : ContentPage
    {
        private readonly BookService _bookService;
        private readonly AddBookViewModel _viewModel;

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is AddBookViewModel viewModel)
            {
                viewModel.SubjectSuggestions = _bookService.GetSubjectsSuggestions();
                viewModel.VibeSuggestions = _bookService.GetVibeSuggestions();
                viewModel.SourceSuggestions = _bookService.GetSourceSuggestions();

                // Notify the UI
                viewModel.OnPropertyChanged(nameof(viewModel.SubjectSuggestions));
                viewModel.OnPropertyChanged(nameof(viewModel.VibeSuggestions));
                viewModel.OnPropertyChanged(nameof(viewModel.SourceSuggestions));
            }
        }

        public AddBookPage(BookService bookService)
        {
            InitializeComponent();
            _bookService = bookService;
            _viewModel = new AddBookViewModel(bookService);
            BindingContext = _viewModel;
        }


        private async void OnUploadClicked(object sender, EventArgs e)
        {
            var file = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images
            });

            if (file != null)
            {
                var imagePath = file.FullPath;
                IconPicker.SelectedItem = imagePath;
            }


        }

        private async void OnCameraClicked(object sender, EventArgs e)
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                var photo = await MediaPicker.Default.CapturePhotoAsync();
                if (photo != null)
                {
                    var stream = await photo.OpenReadAsync();
                    var path = photo.FullPath;
                    IconPicker.SelectedItem = path;
                }
            }
            else
            {
                await DisplayAlert("Camera Unavailable", "This device does not support camera capture.", "OK");
            }
        }
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Clicked Save Book");
            if (BindingContext is not AddBookViewModel viewModel)
            {
                Debug.WriteLine("BindingContext is not AddBookViewModel");
                return;
            }

            if (!int.TryParse(viewModel.YearText?.Trim(), out int year) ||
                !int.TryParse(viewModel.PagesText?.Trim(), out int pages))
            {
                await DisplayAlert("Error", "Please fill in all fields correctly.", "OK");
                return;
            }

            var book = viewModel.CreateBook();
            book.YearPublished = year;
            book.Pages = pages;

            _bookService.AddBook(book);

            bool addAnother = await DisplayAlert(
                "Success",
                $"\"{book.Title}\" added to your TBR list!",
                "Add Another",
                "Return to List");

            if (addAnother)
            {
                viewModel.ClearForm();
                viewModel.RefreshSuggestions();
            }
            else
            {
                viewModel.ClearForm();
                viewModel.RefreshSuggestions();
                await Shell.Current.GoToAsync($"//{nameof(TBRListPage)}");
            }
        }

            private void OnAuthorTextChanged(object sender, TextChangedEventArgs e)
        {
            if (BindingContext is AddBookViewModel vm)
                vm.FilterAuthorSuggestions(e.NewTextValue);
        }

        private void OnCountryTextChanged(object sender, TextChangedEventArgs e)
        {
            if (BindingContext is AddBookViewModel vm)
                vm.FilterCountrySuggestions(e.NewTextValue);
        }

        private void OnSubjectTextChanged(object sender, TextChangedEventArgs e)
        {
            if (BindingContext is AddBookViewModel vm)
                vm.FilterSubjectsSuggestions(e.NewTextValue);
        }

        private void OnVibeTextChanged(object sender, TextChangedEventArgs e)
        {
            if (BindingContext is AddBookViewModel vm)
                vm.FilterVibeSuggestions(e.NewTextValue);
        }

        private void OnSourceTextChanged(object sender, TextChangedEventArgs e)
        {
            if (BindingContext is AddBookViewModel vm)
                vm.FilterSourceSuggestions(e.NewTextValue);
        }
    }

}


