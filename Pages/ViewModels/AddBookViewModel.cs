using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TBRAppMobile.Models;
using TBRAppMobile.Services;
using System.Windows.Input;
using TBRAppMobile.Helpers;
using TBRAppMobile.Pages;
using Microsoft.Maui.Controls;

//This ViewModel for the AddBook page implements dynamic changes made on the page throughout the app
namespace TBRAppMobile.ViewModels;

public class AddBookViewModel : INotifyPropertyChanged
{
    private readonly BookService _bookService;
    private readonly GoogleBooksService _googleBooksService;

    public event PropertyChangedEventHandler? PropertyChanged;
    public ObservableCollection<string> DefaultIcons { get; set; } = new();
    private ObservableCollection<Book> _searchResults = new();

    public void OnPropertyChanged([CallerMemberName] string name = "") =>
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public AddBookViewModel(BookService bookService, GoogleBooksService googleBooksService)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
        _bookService = bookService;
        _googleBooksService = googleBooksService;

        DefaultIcons = new ObservableCollection<string>
        {
            "book_alloy.png", "book_cyan.png", "book_red.png", "book_green.png",
            "book_yellow.png", "book_purple.png", "book_darkgreen.png", "book_black.png"
        };

        SubjectSuggestions = new ObservableCollection<string>();
        VibeSuggestions = new ObservableCollection<string>();
        SourceSuggestions = new ObservableCollection<string>();
        AuthorSuggestions = new ObservableCollection<string>();
        CountrySuggestions = new ObservableCollection<string>();

    }

    //Google Search results drop down 
    public ObservableCollection<Book> SearchResults
    {
        get => _searchResults;
        set => SetProperty(ref _searchResults, value);
    }

    private Book? _selectedSearchResult;
    private bool _isSearchDropdownVisible;
    public bool IsSearchDropdownVisible
    {
        get => _isSearchDropdownVisible;
        set => SetProperty(ref _isSearchDropdownVisible, value);
    }

    public Book? SelectedSearchResult
    {
        get => _selectedSearchResult;
        set
        {
            SetProperty(ref _selectedSearchResult, value);

            if (value != null)
            {
                PopulateFromGoogleBook(value);
                SearchResults.Clear();
                IsSearchDropdownVisible = false;
            }
        }
    }

    //updates properties when user makes changes
    private string _title = string.Empty;
    public string BookTitle
    {
        get => _title;
        set { _title = value; OnPropertyChanged(); }
    }

    private string _authorText = string.Empty;

    //Dynamic typing recognition/suggestions: i.e. if the author exist in the app it will recognize and suggest author as you type
    public string AuthorText
    {
        get => _authorText;
        set
        {
            SetProperty(ref _authorText, value);
            FilterAuthorSuggestions(value);
        }
    }

    public ObservableCollection<string> AuthorSuggestions { get; set; } = new();
    public ObservableCollection<string> FilteredAuthorSuggestions { get; set; } = new();

    public void FilterAuthorSuggestions(string input)
    {
        AutoCompleteManager.FilterSuggestions(
            input,
            AuthorSuggestions,
            FilteredAuthorSuggestions,
            visible => IsAuthorSuggestionsVisible = visible);
    }

    private string _countryText = string.Empty;
    public string CountryText
    {
        get => _countryText;
        set
        {
            SetProperty(ref _countryText, value);
            FilterCountrySuggestions(value);
        }
    }

    public ObservableCollection<string> CountrySuggestions { get; set; } = new();

    public ObservableCollection<string> FilteredCountrySuggestions { get; set; } = new();

    public void FilterCountrySuggestions(string input)
    {
        AutoCompleteManager.FilterSuggestions(
            input,
            CountrySuggestions,
            FilteredCountrySuggestions,
            visible => IsCountrySuggestionsVisible = visible);
    }


    private string _yearText = string.Empty;
    public string YearText
    {
        get => _yearText;
        set { _yearText = value; OnPropertyChanged(); }
    }

    private string _pagesText = string.Empty;
    public string PagesText
    {
        get => _pagesText;
        set { _pagesText = value; OnPropertyChanged(); }
    }


    public ObservableCollection<string> SubjectSuggestions { get; set; } = new();
    public ObservableCollection<string> VibeSuggestions { get; set; } = new();
    public ObservableCollection<string> SourceSuggestions { get; set; } = new();

    private string? _selectedSubject = string.Empty;
    public string? SelectedSubject
    {
        get => _selectedSubject;
        set { _selectedSubject = value; OnPropertyChanged(); }
    }

    private string? _SubjectText = string.Empty;
    public string? SubjectText
    {
        get => _SubjectText;
        set
        {
            SetProperty(ref _SubjectText, value);
            FilterSubjectsSuggestions(value ?? string.Empty);
        }
    }



    public ObservableCollection<string> FilteredSubjectsSuggestions { get; set; } = new();

    public void FilterSubjectsSuggestions(string input)
    {
        AutoCompleteManager.FilterSuggestions(
            input,
            SubjectSuggestions,
            FilteredSubjectsSuggestions,
            visible => IsSubjectsSuggestionsVisible = visible);
    }


    private string? _selectedVibe = string.Empty;
    public string? SelectedVibe
    {
        get => _selectedVibe;
        set { _selectedVibe = value; OnPropertyChanged(); }
    }

    private string? _VibeText = string.Empty;
    public string? VibeText
    {
        get => _VibeText;
        set
        {
            SetProperty(ref _VibeText, value);
            FilterVibeSuggestions(value ?? string.Empty);
        }
    }

    public ObservableCollection<string> FilteredVibeSuggestions { get; set; } = new();

    public void FilterVibeSuggestions(string input)
    {
        AutoCompleteManager.FilterSuggestions(
            input,
            VibeSuggestions,
            FilteredVibeSuggestions,
            visible => IsVibeSuggestionsVisible = visible);
    }


    private string? _selectedSource = string.Empty;
    public string? SelectedSource
    {
        get => _selectedSource;
        set { _selectedSource = value; OnPropertyChanged(); }   
    }

    private string? _SourceText = string.Empty;
    public string? SourceText
    {
        get => _SourceText;
        set
        {
            SetProperty(ref _SourceText, value);
            FilterSourceSuggestions(value ?? string.Empty);
        }
    }

    public ObservableCollection<string> FilteredSourceSuggestions { get; set; } = new();

    public void FilterSourceSuggestions(string input)
    {
        AutoCompleteManager.FilterSuggestions(
            input,
            SourceSuggestions,
            FilteredSourceSuggestions,
            visible => IsSourceSuggestionsVisible = visible);
    }


    private string? _selectedIcon = string.Empty;
    public string? SelectedIcon
    {
        get => _selectedIcon;
        set { _selectedIcon = value; OnPropertyChanged(); }
    }

    private bool _isAuthorSuggestionsVisible;
    public bool IsAuthorSuggestionsVisible
    {
        get => _isAuthorSuggestionsVisible;
        set
        {
            _isAuthorSuggestionsVisible = value;
            OnPropertyChanged();
        }
    }

    private bool _isCountrySuggestionsVisible;
    public bool IsCountrySuggestionsVisible
    {
        get => _isCountrySuggestionsVisible;
        set
        {
            _isCountrySuggestionsVisible = value;
            OnPropertyChanged();
        }
    }

    private bool _isSubjectsSuggestionsVisible;
    public bool IsSubjectsSuggestionsVisible
    {
        get => _isSubjectsSuggestionsVisible;
        set
        {
            _isSubjectsSuggestionsVisible = value;
            OnPropertyChanged();
        }
    }

    private bool _isVibeSuggestionsVisible;
    public bool IsVibeSuggestionsVisible
    {
        get => _isVibeSuggestionsVisible;
        set
        {
            _isVibeSuggestionsVisible = value;
            OnPropertyChanged();
        }
    }

    private bool _isSourceSuggestionsVisible;
    public bool IsSourceSuggestionsVisible
    {
        get => _isSourceSuggestionsVisible;
        set
        {
            _isSourceSuggestionsVisible = value;
            OnPropertyChanged();
        }
    }

    public void ReplaceSuggestions(
    IEnumerable<string> subjects,
    IEnumerable<string> vibes,
    IEnumerable<string> sources,
    IEnumerable<string> authors,
    IEnumerable<string> countries)
    {
        void Reset(ObservableCollection<string> oc, IEnumerable<string> items)
        {
            oc.Clear();
            foreach (var s in items) oc.Add(s);
        }

        // must be on UI thread
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Reset(SubjectSuggestions, subjects);
            Reset(VibeSuggestions, vibes);
            Reset(SourceSuggestions, sources);
            Reset(AuthorSuggestions, authors);
            Reset(CountrySuggestions, countries);

            OnPropertyChanged(nameof(SubjectSuggestions));
            OnPropertyChanged(nameof(VibeSuggestions));
            OnPropertyChanged(nameof(SourceSuggestions));
            OnPropertyChanged(nameof(AuthorSuggestions));
            OnPropertyChanged(nameof(CountrySuggestions));
        });
    }

    //allows selection of suggestion
    public ICommand SelectAuthorCommand => new Command<string>(selected =>
    {
        AuthorText = selected;
        IsAuthorSuggestionsVisible = false;
        _bookService.BumpAuthor(selected);
        RefreshSuggestions();
    });

    public ICommand SelectCountryCommand => new Command<string>(selected =>
    {
        CountryText = selected;
        IsCountrySuggestionsVisible = false;
        _bookService.BumpCountry(selected);
        RefreshSuggestions();
    });

    public ICommand SelectSubjectsCommand => new Command<string>(selected =>
    {
        SubjectText = selected;
        IsSubjectsSuggestionsVisible = false;
        _bookService.BumpSubject(selected);
        RefreshSuggestions();
    });

    public ICommand SelectVibeCommand => new Command<string>(selected =>
    {
        VibeText = selected;
        IsVibeSuggestionsVisible = false;
        _bookService.BumpVibe(selected);
        RefreshSuggestions();
    });

    public ICommand SelectSourceCommand => new Command<string>(selected =>
    {
        SourceText = selected;
        IsSourceSuggestionsVisible = false;
        _bookService.BumpSource(selected);
        RefreshSuggestions();
    });


    private bool _isGoogleImage;
    public bool IsGoogleImage
    {
        get => _isGoogleImage;
        set => SetProperty(ref _isGoogleImage, value);
    }


    //GoogleBooks Search Code
    public void PopulateFromGoogleBook(Book book)
    {
        BookTitle = book.Title;
        AuthorText = book.Author;
        PagesText = book.Pages > 0 ? book.Pages.ToString() : string.Empty;
        CountryText = book.Country;
        YearText = book.YearPublished > 0 ? book.YearPublished.ToString() : string.Empty;
        SelectedIcon = book.IconPath;
        IsGoogleImage = !string.IsNullOrEmpty(book.IconPath);
    }

    //method for implementing updates made by users
    private void SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return;

        backingStore = value;
        OnPropertyChanged(propertyName ?? string.Empty);
    }

    //Method creates a book, assigns values to properties, and saves it in the app
    public Book CreateBook()
    {
        var subject = !string.IsNullOrWhiteSpace(SubjectText) ? SubjectText : SelectedSubject;
        var vibe = !string.IsNullOrWhiteSpace(VibeText) ? VibeText : SelectedVibe;
        var source = !string.IsNullOrWhiteSpace(SourceText) ? SourceText : SelectedSource;

        // bump usage so the next RefreshSuggestions shows updated top-5
        _bookService.BumpSubject(subject);
        _bookService.BumpVibe(vibe);
        _bookService.BumpSource(source);
        _bookService.BumpAuthor(AuthorText);
        _bookService.BumpCountry(CountryText);

        var book = new Book
        {
            Title = BookTitle,
            Author = AuthorText,
            Country = CountryText,
            Subject = subject,
            Vibe = vibe,
            Source = source,
            IconPath = SelectedIcon ?? "book_cyan.png"
        };

        return book;
    }

    private static bool ContainsIgnoreCase(ObservableCollection<string> oc, string? s)
        => !string.IsNullOrWhiteSpace(s) && oc.Any(x => string.Equals(x, s, StringComparison.OrdinalIgnoreCase));

    public void ForceIncludeRecentChoices(string? subject, string? vibe, string? source)
    {
        if (!string.IsNullOrWhiteSpace(subject) && !ContainsIgnoreCase(SubjectSuggestions, subject))
            SubjectSuggestions.Insert(0, subject.Trim());

        if (!string.IsNullOrWhiteSpace(vibe) && !ContainsIgnoreCase(VibeSuggestions, vibe))
            VibeSuggestions.Insert(0, vibe.Trim());

        if (!string.IsNullOrWhiteSpace(source) && !ContainsIgnoreCase(SourceSuggestions, source))
            SourceSuggestions.Insert(0, source.Trim());
    }

    private string _searchQuery = string.Empty;
    public string SearchQuery
    {
        get => _searchQuery;
        set => SetProperty(ref _searchQuery, value);
    }

    //used to clear fields after user submits a change
    public void ClearForm()
    {
        SearchQuery = string.Empty;
        SearchResults.Clear();
        IsSearchDropdownVisible = false;

        BookTitle = string.Empty;
        AuthorText = string.Empty;
        YearText = string.Empty;
        PagesText = string.Empty;
        CountryText = string.Empty;
        SelectedSubject = null;
        SubjectText = string.Empty;

        SelectedVibe = null;
        VibeText = string.Empty;

        SelectedSource = null;
        SourceText = string.Empty;

        SelectedIcon = null;
        IsGoogleImage = false;

        FilteredAuthorSuggestions.Clear();
        FilteredCountrySuggestions.Clear();
        FilteredSubjectsSuggestions.Clear();
        FilteredVibeSuggestions.Clear();
        FilteredSourceSuggestions.Clear();

        IsAuthorSuggestionsVisible = false;
        IsCountrySuggestionsVisible = false;
        IsSubjectsSuggestionsVisible = false;
        IsVibeSuggestionsVisible = false;
        IsSourceSuggestionsVisible = false;
    }

    //these properties are dynamic and suggestions are based off previous user input. This method updates the pages to provide the relevent suggestions
    public void RefreshSuggestions()
    {
        SubjectSuggestions.Clear();
        foreach (var item in _bookService.GetSubjectsSuggestions())
            SubjectSuggestions.Add(item);
        VibeSuggestions.Clear();
        foreach (var item in _bookService.GetVibeSuggestions())
            VibeSuggestions.Add(item);
        SourceSuggestions.Clear();
        foreach (var item in _bookService.GetSourceSuggestions())
            SourceSuggestions.Add(item);
        AuthorSuggestions.Clear();
        foreach (var item in _bookService.GetAuthorSuggestions())
            AuthorSuggestions.Add(item);
        CountrySuggestions.Clear();
        foreach (var item in _bookService.GetCountrySuggestions())
            CountrySuggestions.Add(item);

        OnPropertyChanged(nameof(SubjectSuggestions));
        OnPropertyChanged(nameof(VibeSuggestions));
        OnPropertyChanged(nameof(SourceSuggestions));
        OnPropertyChanged(nameof(AuthorSuggestions));
        OnPropertyChanged(nameof(CountrySuggestions));
    }
}



