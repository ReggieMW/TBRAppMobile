using TBRAppMobile.Models;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TBRAppMobile.Services;

public class BookService
{
    private readonly ObservableCollection<Book> _allBooks = new();

    private readonly Dictionary<string, int> _subjectHistory = new();
    private readonly Dictionary<string, int> _vibeHistory = new();
    private readonly Dictionary<string, int> _sourceHistory = new();

    private readonly ObservableCollection<string> _defaultSubjects = new()
    {
        "Love", "Life", "Outer Space", "Kings & Queens & Realms", "Murder"
    };

    private readonly ObservableCollection<string> _defaultVibes = new()
    {
        "Sad", "Scary", "Hopeful", "Funny", "Thoughtful"
    };

    private readonly ObservableCollection<string> _defaultSources = new()
    {
        "Recommended", "BookTok", "Cool Cover", "Review", "Love the Author", "Book Club Book"
    };

    public IReadOnlyList<Book> AllBooks => _allBooks;
    public ObservableCollection<Book> TBRBooks { get; } = new();
    public ObservableCollection<Book> ReadBooks { get; } = new();
    public ObservableCollection<Book> CurrentReadBooks { get; } = new();
    public ObservableCollection<Book> CanonBooks { get; } = new();


    public void AddBook(Book book)
    {
        book.Status = BookStatus.TBR;
        _allBooks.Add(book);
        TBRBooks.Add(book);
        UpdateSuggestions(_subjectHistory, book.Subject);
        UpdateSuggestions(_vibeHistory, book.Vibe);
        UpdateSuggestions(_sourceHistory, book.Source);

        Debug.WriteLine($"Added book: {book.Title}");
    }

    public void MarkAsRead(Book book, string? newVibe = null, string? comparable = null)
    {
        book.Status = BookStatus.Read;

        if (!string.IsNullOrWhiteSpace(newVibe))
        {
            book.Vibe = newVibe;
            UpdateSuggestions(_vibeHistory, newVibe);
        }

        if (!string.IsNullOrWhiteSpace(comparable))
        {
            book.Comparable = comparable;
        }
    }

    public void UpdateBookStatus(Book book, BookStatus newStatus)
    {
        RemoveFromAllStatusCollections(book);

        book.Status = newStatus;

        switch (newStatus)
        {
            case BookStatus.TBR:
                TBRBooks.Add(book);
                break;
            case BookStatus.Read:
                ReadBooks.Add(book);
                break;
            case BookStatus.CurrentReads:
                CurrentReadBooks.Add(book);
                break;
        }
    }

    private void RemoveFromAllStatusCollections(Book book)
    {
        TBRBooks.Remove(book);
        ReadBooks.Remove(book);
        CurrentReadBooks.Remove(book);
    }

    public void RemoveBook(Book book)
    {
        _allBooks.Remove(book);
        TBRBooks.Remove(book);
        ReadBooks.Remove(book);
        CurrentReadBooks.Remove(book);
        CanonBooks.Remove(book);
    }

    public void MarkAsCurrentRead(Book book)
    {
        UpdateBookStatus(book, BookStatus.CurrentReads);
    }

    public void AddToCanon(Book book)
    {
        if (!CanonBooks.Contains(book))
        {
            book.IsCanon = true;
            CanonBooks.Add(book);
        }
    }

    public ObservableCollection<Book> GetAllBooks()
    {
        return _allBooks;
    }

    public ObservableCollection<Book> GetTBR_Books()
    {
        return new ObservableCollection<Book>(_allBooks.Where(b => b.Status == BookStatus.TBR));
    }

    public ObservableCollection<Book> GetCurrentReads()
    {
        return new ObservableCollection<Book>(_allBooks.Where(b => b.Status == BookStatus.CurrentReads));
    }

    public ObservableCollection<Book> GetReadBooks()
    {
        return new ObservableCollection<Book>(_allBooks.Where(b => b.Status == BookStatus.Read));
    }

    public ObservableCollection<Book> GetDNFBooks()
    {
        return new ObservableCollection<Book>(_allBooks.Where(b => b.Status == BookStatus.DNF));
    }

    public ObservableCollection<Book> GetCanonBooks()
    {
        return CanonBooks;
    }

    public ObservableCollection<string> GetSubjectsSuggestions() => GetTopSuggestions(_subjectHistory, _defaultSubjects);
    public ObservableCollection<string> GetVibeSuggestions() => GetTopSuggestions(_vibeHistory, _defaultVibes);
    public ObservableCollection<string> GetSourceSuggestions() => GetTopSuggestions(_sourceHistory, _defaultSources);

    private static void UpdateSuggestions(Dictionary<string, int> history, string? value)
    {
        if (string.IsNullOrWhiteSpace(value)) return;

        if (history.ContainsKey(value))
            history[value]++;
        else
            history[value] = 1;
    }

    private static ObservableCollection<string> GetTopSuggestions(
    Dictionary<string, int> history,
    ObservableCollection<string>? defaults = null)
    {
        return new ObservableCollection<string>(
            history
                .OrderByDescending(kv => kv.Value)
                .Take(5)
                .Select(kv => kv.Key)
                .Concat(defaults?.Except(history.Keys).Take(5 - history.Count) ?? Enumerable.Empty<string>())
                .Distinct()
                .ToList()
        );
    }

#if DEBUG
    public void SeedTestBooks()
    {
        if (_allBooks.Any()) return;

        AddBook(new Book { Title = "The Left Hand of Darkness", Author = "Ursula K. Le Guin", YearPublished = 1969, Pages = 304, Country = "USA", Subject = "Outer Space", Vibe = "Thoughtful", Source = "Recommendation", Status = BookStatus.TBR });
        AddBook(new Book { Title = "Beloved", Author = "Toni Morrison", YearPublished = 1987, Pages = 324, Country = "USA", Subject = "Love", Vibe = "Sad", Source = "Book Club Book", Status = BookStatus.Read });
        AddBook(new Book { Title = "Blood Meridian", Author = "Cormac McCarthy", YearPublished = 1985, Pages = 348, Country = "USA", Subject = "Violence", Vibe = "Dark", Source = "Review", Status = BookStatus.CurrentReads });
        AddBook(new Book { Title = "House of Leaves", Author = "Mark Z. Danielewski", YearPublished = 2000, Pages = 709, Country = "USA", Subject = "Scary Stuff", Vibe = "Scary", Source = "Cool Cover", Status = BookStatus.DNF });
    }
#endif

}
