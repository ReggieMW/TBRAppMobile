using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using TBRAppMobile.Models;
using TBRAppMobile.Services;

namespace TBRAppMobile.Pages
{
    public partial class AddBookPage : ContentPage
    {
        private readonly BookService _bookService;

        public ObservableCollection<string>? SubjectSuggestions { get; set; }
        public ObservableCollection<string>? VibeSuggestions { get; set; }
        public ObservableCollection<string>? SourceSuggestions { get; set; }
        public ObservableCollection<string> DefaultIcons { get; set; }

        public AddBookPage(BookService bookService)
        {
            InitializeComponent();
            _bookService = bookService;

            SubjectSuggestions = _bookService.GetSubjectsSuggestions();
            VibeSuggestions = _bookService.GetVibeSuggestions();
            SourceSuggestions = _bookService.GetSourceSuggestions();
            DefaultIcons = new ObservableCollection<string>(new[]
        {
                "book_alloy.png", "book_cyan.png", "book_red.png", "book_green.png",
                "book_yellow.png", "book_purple.png", "book_darkgreen.png", "book_black.png"
            });

            BindingContext = this;
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
                DefaultIcons.Add(imagePath);  // Show in icon picker
                IconPicker.SelectedItem = imagePath; // Select it
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
                    DefaultIcons.Add(path);
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
            string? title = TitleEntry.Text?.Trim();
            string? author = AuthorEntry.Text?.Trim();
            string? yearText = YearEntry.Text?.Trim();
            string? pagesText = PagesEntry.Text?.Trim();

            // Basic validation
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) ||
                !int.TryParse(yearText, out int year) || !int.TryParse(pagesText, out int pages))
            {
                await DisplayAlert("Error", "Please fill in all fields correctly.", "OK");
                return;
            }

            var book = new Book
            {
                Title = title,
                Author = author,
                Country = CountryEntry.Text?.Trim(),
                Subject = SubjectPicker.SelectedItem?.ToString(),
                Vibe = VibePicker.SelectedItem?.ToString(),
                Source = SourcePicker.SelectedItem?.ToString(),
                IconPath = IconPicker.SelectedItem?.ToString() ?? "book_cyan.png",
                YearPublished = year,
                Pages = pages
            };

            _bookService.AddBook(book);

            bool addAnother = await DisplayAlert(
    "Success",
    $"\"{book.Title}\" added to your TBR list!",
    "Add Another",
    "Return to List");

            if (addAnother)
            {
                ClearForm();
            }
            else
            {
                await Shell.Current.GoToAsync("..");
            }

        }

        private void OnSubjectSelected(object sender, EventArgs e)
        {
            if (SubjectPicker.SelectedIndex != -1)
            {
                SubjectEntry.Text = SubjectPicker.SelectedItem.ToString();
            }
        }

        private void OnVibeSelected(object sender, EventArgs e)
        {
            if (VibePicker.SelectedIndex != -1)
            {
                VibeEntry.Text = VibePicker.SelectedItem.ToString();
            }
        }

        private void OnSourceSelected(object sender, EventArgs e)
        {
            if (SourcePicker.SelectedIndex != -1)
            {
                SourceEntry.Text = SourcePicker.SelectedItem.ToString();
            }
        }
        
        private void ClearForm()
        {
            TitleEntry.Text = string.Empty;
            AuthorEntry.Text = string.Empty;
            YearEntry.Text = string.Empty;
            PagesEntry.Text = string.Empty;
            CountryEntry.Text = string.Empty;

            SubjectPicker.SelectedIndex = -1;
            VibePicker.SelectedIndex = -1;
            SourcePicker.SelectedIndex = -1;

            SubjectEntry.Text = string.Empty;
            VibeEntry.Text = string.Empty;
            SourceEntry.Text = string.Empty;

            IconPicker.SelectedItem = null;
        }
    }
}

