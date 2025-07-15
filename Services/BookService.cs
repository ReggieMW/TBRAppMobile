using TBRAppMobile.Models;

namespace TBRAppMobile.Services;

public class BookService
{
    private readonly List<Book> _allBooks = new();
    private readonly List<Book> _readBooks = new();
    private readonly List<Book> _canon = new();
    private readonly List<Book> _currentReads = new();

    private readonly Dictionary<string, int> _subjectHistory = new();
    private readonly Dictionary<string, int> _vibeHistory = new();
    private readonly Dictionary<string, int> _sourceHistory = new();

    private readonly List<string> _defaultSubjects = new()
    {
        "Love", "Life", "Outer Space", "Kings & Queens & Realms", "Murder"
    };

    private readonly List<string> _defaultVibes = new()
    {
        "Sad", "Scary", "Hopeful", "Funny", "Thoughtful"
    };

    private readonly List<string> _defaultSources = new()
    {
        "Recommended", "BookTok", "Cool Cover", "Review", "Love the Author", "Book Club Book"
    };

    public IReadOnlyList<Book> AllBooks => _allBooks;
    public IReadOnlyList<Book> ReadBooks => _readBooks;
    public IReadOnlyList<Book> CurrentReads => _currentReads;
    public IReadOnlyList<Book> Canon => _canon;

    public void AddBook(Book book)
    {
        book.Status = BookStatus.TBR;
        _allBooks.Add(book);
        UpdateSuggestions(_subjectHistory, book.Subject);
        UpdateSuggestions(_vibeHistory, book.Vibe);
        UpdateSuggestions(_sourceHistory, book.Source);
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


    public void MarkAsCurrentRead(Book book)
    {
        book.Status = BookStatus.CurrentRead;
        _currentReads.Add(book);
    }

    public void AddToCanon(Book book)
    {
        if (!_canon.Contains(book))
        {
            book.IsCanon = true;
            _canon.Add(book);
        }
    }

    public List<Book> GetTBRBooks()
    {
        return _allBooks.Where(b => b.Status == BookStatus.TBR).ToList();
    }

    public List<Book> GetCurrentReads()
    {
        return _allBooks.Where(b => b.Status == BookStatus.CurrentRead).ToList();
    }

    public List<Book> GetReadBooks()
    {
        return _allBooks.Where(b => b.Status == BookStatus.Read).ToList();
    }

    public List<Book> GetCanonBooks()
    {
        return _canon;
    }

    public List<string> GetSubjectsSuggestions() => GetTopSuggestions(_subjectHistory, _defaultSubjects);
    public List<string> GetVibeSuggestions() => GetTopSuggestions(_vibeHistory, _defaultVibes);
    public List<string> GetDiscoverSuggestions() => GetTopSuggestions(_sourceHistory, _defaultSources);

    private static void UpdateSuggestions(Dictionary<string, int> history, string? value)
    {
        if (string.IsNullOrWhiteSpace(value)) return;

        if (history.ContainsKey(value))
            history[value]++;
        else
            history[value] = 1;
    }

    private static List<string> GetTopSuggestions(Dictionary<string, int> history, List<string>? defaults = null)
    {
        return history
            .OrderByDescending(kv => kv.Value)
            .Take(5)
            .Select(kv => kv.Key)
            .Concat(defaults?.Except(history.Keys).Take(5 - history.Count) ?? Enumerable.Empty<string>())
            .Distinct()
            .ToList();
    }
}
