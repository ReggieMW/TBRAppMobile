using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TBRAppMobile.Models;
using TBRAppMobile.Services;
using System.Windows.Input;
using TBRAppMobile.Helpers;
using Microsoft.Maui.Controls;


namespace TBRAppMobile.ViewModels;

public class AddBookViewModel : INotifyPropertyChanged
{
    private readonly BookService _bookService;

    public event PropertyChangedEventHandler? PropertyChanged;
    public ObservableCollection<string> DefaultIcons { get; set; } = new();

    public void OnPropertyChanged([CallerMemberName] string name = "") =>
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    public AddBookViewModel(BookService bookService)
    {
        _bookService = bookService;

        SubjectSuggestions = _bookService.GetSubjectsSuggestions();
        VibeSuggestions = _bookService.GetVibeSuggestions();
        SourceSuggestions = _bookService.GetSourceSuggestions();
        DefaultIcons = new ObservableCollection<string>
        {
            "book_alloy.png", "book_cyan.png", "book_red.png", "book_green.png",
            "book_yellow.png", "book_purple.png", "book_darkgreen.png", "book_black.png"
        };
    }

    private string _title = string.Empty;
    public string BookTitle
    {
        get => _title;
        set { _title = value; OnPropertyChanged(); }
    }

    private string _authorText = string.Empty;
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

    public ICommand SelectAuthorCommand => new Command<string>((selected) =>
{
    AuthorText = selected;
    IsAuthorSuggestionsVisible = false;
});

    public ICommand SelectCountryCommand => new Command<string>((selected) =>
    {
        CountryText = selected;
        IsCountrySuggestionsVisible = false;
    });

    public ICommand SelectSubjectsCommand => new Command<string>((selected) =>
    {
        SubjectText = selected;
        IsSubjectsSuggestionsVisible = false;
    });

    public ICommand SelectVibeCommand => new Command<string>((selected) =>
    {
        VibeText = selected;
        IsVibeSuggestionsVisible = false;
    });

    public ICommand SelectSourceCommand => new Command<string>((selected) =>
    {
        SourceText = selected;
        IsSourceSuggestionsVisible = false;
    });


    private void SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return;

        backingStore = value;
        OnPropertyChanged(propertyName ?? string.Empty);
    }


    public Book CreateBook()
    {
        return new Book
        {
            Title = BookTitle,
            Author = AuthorText,
            Country = CountryText,
            Subject = !string.IsNullOrWhiteSpace(SubjectText) ? SubjectText : SelectedSubject,
            Vibe = !string.IsNullOrWhiteSpace(VibeText) ? VibeText : SelectedVibe,
            Source = !string.IsNullOrWhiteSpace(SourceText) ? SourceText : SelectedSource,
            IconPath = SelectedIcon ?? "book_cyan.png"
        };
    }

    public void ClearForm()
    {
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



