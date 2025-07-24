using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TBRAppMobile.Models;

//Book properties
public class Book : INotifyPropertyChanged
{
    private string _title = string.Empty;
    private string _author = string.Empty;
    private int _yearPublished;
    private int _pages;
    private string? _country = string.Empty;
    private string? _subject = string.Empty;
    private string? _vibe = string.Empty;
    private string? _source = string.Empty;
    private BookStatus _status;
    private bool _isCanon;
    private string? _iconPath;

//syncs with UI so when a book property is added or updated it syncs across the app
    public string Title
    {
        get => _title;
        set { _title = value; OnPropertyChanged(); }
    }

    public string Author
    {
        get => _author;
        set { _author = value; OnPropertyChanged(); }
    }

    public int YearPublished
    {
        get => _yearPublished;
        set { _yearPublished = value; OnPropertyChanged(); }
    }

    public int Pages
    {
        get => _pages;
        set { _pages = value; OnPropertyChanged(); }
    }

    public string? Country
    {
        get => _country;
        set { _country = value; OnPropertyChanged(); }
    }

    public string? Subject
    {
        get => _subject;
        set { _subject = value; OnPropertyChanged(); }
    }

    public string? Vibe
    {
        get => _vibe;
        set { _vibe = value; OnPropertyChanged(); }
    }

    public string? Source
    {
        get => _source;
        set { _source = value; OnPropertyChanged(); }
    }

//Book Status reflects the users current relationship with the book, Dynamic and updated by user
    public BookStatus Status
    {
        get => _status;
        set
        {
            if (_status != value)
            {
                _status = value;
                OnPropertyChanged();
            }
        }
    }

//A favorites list, more or less
    public bool IsCanon
    {
        get => _isCanon;
        set
        {
            if (_isCanon != value)
            {
                _isCanon = value;
                OnPropertyChanged();
            }
        }
    }

//property allowing user to provide a comparison to a book
    private string? _comparable;
    public string? Comparable
    {
        get => _comparable;
        set
        {
            if (_comparable != value)
            {
                _comparable = value;
                OnPropertyChanged();
            }
        }
    }



    public bool Recommended { get; set; }

//Default icon in several different colors for users who don't provide their own image for a book *one of these isn't working!
    private static readonly string[] DefaultIcons =
    {
        "book_alloy.png",
        "book_red.png",
        "boook_green.png",
        "book_yellow.png",
        "book_purple.png",
        "book_darkgreen.png",
        "book_black.png",
        "book_cyan.png"
    };

    private readonly string _defaultIcon = DefaultIcons[new Random().Next(DefaultIcons.Length)];

    public string IconPath
    {
        get => _iconPath ?? _defaultIcon;
        set { _iconPath = value; OnPropertyChanged(); }
    }

//property change logic for UI
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
