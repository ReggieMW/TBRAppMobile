using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using TBRAppMobile.Models;
using TBRAppMobile.Services;

namespace TBRAppMobile.Pages
{
    public partial class AddBookPage : ContentPage
    {
        public ObservableCollection<string>? SubjectSuggestions { get; set; }
        public ObservableCollection<string>? VibeSuggestions { get; set; }
        public ObservableCollection<string>? SourceSuggestions { get; set; }

        private readonly ListManager _manager;

        public AddBookPage(ListManager manager)
        {
            InitializeComponent();
            _manager = manager;

            SubjectSuggestions = new ObservableCollection<string>(_manager.GetTopSubjects());
            VibeSuggestions = new ObservableCollection<string>(_manager.GetTopVibes());
            SourceSuggestions = new ObservableCollection<string>(_manager.GetTopSources());

            BindingContext = this;
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            string title = TitleEntry.Text?.Trim() ?? "";
            string author = AuthorEntry.Text?.Trim() ?? "";
            string yearText = YearEntry.Text ?? "";
            string pagesText = PagesEntry.Text ?? "";
            string country = CountryEntry.Text?.Trim() ?? "";
            string subject = SubjectEntry.Text?.Trim() ?? "";
            string vibe = VibeEntry.Text?.Trim() ?? "";
            string source = SourceEntry.Text?.Trim() ?? "";

            // Basic validation
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) ||
                !int.TryParse(yearText, out int year) || !int.TryParse(pagesText, out int pages))
            {
                DisplayAlert("Error", "Please fill in all fields correctly.", "OK");
                return;
            }

            Book newBook = new Book
            {
                Title = title,
                Author = author,
                YearPublished = year,
                Pages = pages,
                Country = country,
                Subject = subject,
                Vibe = vibe,
                Source = source,
                Status = BookStatus.TBR
            };

            _manager.AddBook(newBook);

            StatusLabel.Text = $"✅ \"{newBook.Title}\" added!";
            StatusLabel.IsVisible = true;

            // Clear fields
            TitleEntry.Text = "";
            AuthorEntry.Text = "";
            YearEntry.Text = "";
            PagesEntry.Text = "";
            CountryEntry.Text = "";
            SubjectEntry.Text = "";
            VibeEntry.Text = "";
            SourceEntry.Text = "";
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
    }
}

