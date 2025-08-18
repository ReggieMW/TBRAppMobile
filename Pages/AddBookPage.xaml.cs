using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using TBRAppMobile.Models;
using TBRAppMobile.Services;
using TBRAppMobile.ViewModels;

namespace TBRAppMobile.Pages
{
    public partial class AddBookPage : ContentPage
    {
        private readonly BookService _bookService;
        private readonly AddBookViewModel _viewModel;
        private readonly GoogleBooksService _googleBooksService;
        private bool _isReady = false;
        private CancellationTokenSource? _searchCts;

        public AddBookPage()
        {
            InitializeComponent();

            Debug.WriteLine("[AddBookPage] ctor: start");

            _bookService = App.BookService;
            _googleBooksService = App.GoogleBooksService;

            // IMPORTANT: keep VM ctor light; no DB/IO in VM constructor.
            _viewModel = new AddBookViewModel(_bookService, _googleBooksService);
            BindingContext = _viewModel;

            // Start clean so initial layout is cheap.
            _viewModel.IsSearchDropdownVisible = false;
            _viewModel.SearchResults.Clear();
            _viewModel.SearchQuery = string.Empty;

            _isReady = false;

            Debug.WriteLine("[AddBookPage] ctor: end");
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Debug.WriteLine("[AddBookPage] OnAppearing: start");
            // Allow first frame to render before any background work
            await Task.Yield();

            if (BindingContext is AddBookViewModel vm)
            {
                vm.IsSearchDropdownVisible = false;
                vm.SearchResults.Clear();
                vm.SearchQuery = string.Empty;
            }

            Debug.WriteLine("[AddBookPage] OnAppearing: end");
        }

        // DO NOT use async void here; dispatch to an async method.
        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            Debug.WriteLine("[AddBookPage] OnNavigatedTo");
            _ = LoadSuggestionsAsync();
        }

        private async Task LoadSuggestionsAsync()
        {
            try
            {
                var snap = await Task.Run(() => new
                {
                    subjects = _bookService.GetSubjectsSuggestions(),
                    vibes = _bookService.GetVibeSuggestions(),
                    sources = _bookService.GetSourceSuggestions(),
                    authors = _bookService.GetAuthorSuggestions(),
                    countries = _bookService.GetCountrySuggestions()
                });

                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    // Apply snapshot
                    _viewModel.ReplaceSuggestions(
                        snap.subjects, snap.vibes, snap.sources, snap.authors, snap.countries);

                    // ⬇️ Add this here
                    _viewModel.RefreshSuggestions();   // sync with any bumps done elsewhere

                    // Now wire events and mark ready
                    if (SearchEntry != null)
                        SearchEntry.TextChanged += OnSearchQueryChanged;

                    _isReady = true;
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[AddBookPage] LoadSuggestionsAsync ERROR: {ex}");
                await MainThread.InvokeOnMainThreadAsync(() => _isReady = true);
            }
        }


        protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
        {
            base.OnNavigatedFrom(args);
            Debug.WriteLine("[AddBookPage] OnNavigatedFrom");

            _isReady = false;

            if (SearchEntry != null)
                SearchEntry.TextChanged -= OnSearchQueryChanged;

            _searchCts?.Cancel();
            _searchCts?.Dispose();
            _searchCts = null;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Debug.WriteLine("[AddBookPage] OnDisappearing");

            _isReady = false;

            if (SearchEntry != null)
                SearchEntry.TextChanged -= OnSearchQueryChanged;

            _searchCts?.Cancel();
            _searchCts?.Dispose();
            _searchCts = null;
        }

        // ---------------- Google Search ----------------

        private async void OnSearchQueryChanged(object? sender, TextChangedEventArgs e)
        {
            if (!_isReady) return;

            string? query = e?.NewTextValue;

            _searchCts?.Cancel();
            _searchCts?.Dispose();
            _searchCts = new CancellationTokenSource();
            var token = _searchCts.Token;

            if (string.IsNullOrWhiteSpace(query))
            {
                _viewModel.SearchResults.Clear();
                _viewModel.IsSearchDropdownVisible = false;
                return;
            }

            try
            {
                await Task.Delay(250, token); // debounce
                token.ThrowIfCancellationRequested();

                var results = await _googleBooksService.SearchBooksAsync(query);
                token.ThrowIfCancellationRequested();

                _viewModel.SearchResults = new ObservableCollection<Book>(results ?? new List<Book>());
                _viewModel.IsSearchDropdownVisible = _viewModel.SearchResults.Count > 0;
            }
            catch (OperationCanceledException) { /* normal */ }
            catch (Exception ex)
            {
                Debug.WriteLine($"[AddBookPage] Search failed: {ex}");
                _viewModel.IsSearchDropdownVisible = false;
            }
        }

        // ---------------- Image pickers ----------------
        private static async Task Pulse(View v)
        {
            await v.ScaleTo(0.96, 70, Easing.CubicOut);
            await v.ScaleTo(1.0, 70, Easing.CubicIn);
        }

        private async void OnUploadClicked(object sender, EventArgs e)
        {
            if (sender is View v) await Pulse(v);

            var file = await FilePicker.PickAsync(new PickOptions { FileTypes = FilePickerFileType.Images });
            if (file == null) return;

            var imagesDir = Path.Combine(FileSystem.AppDataDirectory, "images");
            Directory.CreateDirectory(imagesDir);

            var destPath = Path.Combine(imagesDir, Path.GetFileName(file.FullPath));
            File.Copy(file.FullPath, destPath, overwrite: true);

            _viewModel.SelectedIcon = destPath;
            _viewModel.IsGoogleImage = true;
        }

        private async void OnCameraClicked(object sender, EventArgs e)
        {
            if (sender is View v) await Pulse(v);

            if (!MediaPicker.Default.IsCaptureSupported)
            {
                await DisplayAlert("Camera Unavailable", "This device does not support camera capture.", "OK");
                return;
            }

            var photo = await MediaPicker.Default.CapturePhotoAsync();
            if (photo == null) return;

            var imagesDir = Path.Combine(FileSystem.AppDataDirectory, "images");
            Directory.CreateDirectory(imagesDir);

            var destPath = Path.Combine(
                imagesDir,
                $"{Path.GetFileNameWithoutExtension(photo.FileName)}_{DateTimeOffset.Now.ToUnixTimeMilliseconds()}{Path.GetExtension(photo.FileName)}");

            await using (var src = await photo.OpenReadAsync())
            await using (var dst = File.Create(destPath))
                await src.CopyToAsync(dst);

            _viewModel.SelectedIcon = destPath;
            _viewModel.IsGoogleImage = true;
        }



        // ---------------- Save ----------------
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            if (sender is View v) await Pulse(v);

            Debug.WriteLine("[AddBookPage] Clicked Save Book");
            if (BindingContext is not AddBookViewModel viewModel)
            {
                Debug.WriteLine("[AddBookPage] BindingContext is not AddBookViewModel");
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

            book.Status = BookStatus.TBR;

            // Update in-memory first so UI updates immediately
            App.BookService.AddBook(book);

            App.BookService.AddBook(book);
    await App.Database.SaveBookAsync(book);

    viewModel.RefreshSuggestions();
    viewModel.ForceIncludeRecentChoices(book.Subject, book.Vibe, book.Source);

            // Persist (await the async DB call)
            await App.Database.SaveBookAsync(book);

            Debug.WriteLine($"[Save] TBR count now: {App.BookService.TBRBooks?.Count}");

            // If App.Database uses SQLiteAsyncConnection this is fine. If it's sync, wrap in Task.Run.
            await App.Database.SaveBookAsync(book);
            Debug.WriteLine($"[Path] DB is here: {Path.Combine(FileSystem.AppDataDirectory, "books.db3")}");

            bool addAnother = await DisplayAlert(
                "Success",
                $"\"{book.Title}\" added to your TBR list!",
                "Add Another",
                "Return to List");

            if (addAnother)
            {
                viewModel.ClearForm();
                viewModel.RefreshSuggestions();
                return;
            }

            viewModel.ClearForm();
            viewModel.RefreshSuggestions();
            viewModel.ForceIncludeRecentChoices(book.Subject, book.Vibe, book.Source);

            // TEMP: Navigate directly via Shell to eliminate any custom NavigationService quirks
            try
            {
                await Shell.Current.GoToAsync($"//{nameof(TBRListPage)}", true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[AddBookPage] Nav to TBRListPage failed: {ex}");
                await DisplayAlert("Navigation Error", ex.Message, "OK");
            }
        }

        // ---------------- Suggestion filters ----------------
        private void OnAuthorTextChanged(object sender, TextChangedEventArgs e)
            => (BindingContext as AddBookViewModel)?.FilterAuthorSuggestions(e.NewTextValue);

        private void OnCountryTextChanged(object sender, TextChangedEventArgs e)
            => (BindingContext as AddBookViewModel)?.FilterCountrySuggestions(e.NewTextValue);

        private void OnSubjectTextChanged(object sender, TextChangedEventArgs e)
            => (BindingContext as AddBookViewModel)?.FilterSubjectsSuggestions(e.NewTextValue);

        private void OnVibeTextChanged(object sender, TextChangedEventArgs e)
            => (BindingContext as AddBookViewModel)?.FilterVibeSuggestions(e.NewTextValue);

        private void OnSourceTextChanged(object sender, TextChangedEventArgs e)
            => (BindingContext as AddBookViewModel)?.FilterSourceSuggestions(e.NewTextValue);
    }
}
