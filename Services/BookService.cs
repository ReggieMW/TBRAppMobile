using TBRAppMobile.Models;
using TBRAppMobile.Services;
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
    private readonly Dictionary<string, int> _authorHistory = new();
    private readonly Dictionary<string, int> _countryHistory = new();


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
    public ObservableCollection<Book> MyCanon { get; } = new();
    public ObservableCollection<Book> DNFBooks { get; } = new();


    public void AddBook(Book book)
    {
        _allBooks.Add(book);

        switch (book.Status)
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
            case BookStatus.DNF:
                TBRBooks.Add(book);
                break;
        }

        if (book.IsCanon && !MyCanon.Contains(book))
        {
            MyCanon.Add(book);
        }
        UpdateSuggestions(_subjectHistory, book.Subject);
        Debug.WriteLine($"Subject updated: {book.Subject}");
        UpdateSuggestions(_vibeHistory, book.Vibe);
        Debug.WriteLine($"Vibe updated: {book.Vibe}");
        UpdateSuggestions(_sourceHistory, book.Source);
        Debug.WriteLine($"Source updated: {book.Source}");
        UpdateSuggestions(_authorHistory, book.Author);
        UpdateSuggestions(_countryHistory, book.Country);



        Debug.WriteLine($"Added book: {book.Title}");
    }

    public void UpdateBook(Book updatedBook)
    {
        var existingBook = _allBooks.FirstOrDefault(b => b.Title == updatedBook.Title);

        if (existingBook != null)
        {
            // Update properties individually instead of replacing the object
            existingBook.Author = updatedBook.Author;
            existingBook.Subject = updatedBook.Subject;
            existingBook.Vibe = updatedBook.Vibe;
            existingBook.Source = updatedBook.Source;
            existingBook.Country = updatedBook.Country;
            existingBook.Pages = updatedBook.Pages;
            existingBook.YearPublished = updatedBook.YearPublished;
            existingBook.Status = updatedBook.Status;
            existingBook.IsCanon = updatedBook.IsCanon;
            existingBook.Recommended = updatedBook.Recommended;
            existingBook.Comparable = updatedBook.Comparable;
            existingBook.IconPath = updatedBook.IconPath;
        }
        else
        {
            _allBooks.Add(updatedBook); // Book didn't exist — add it
        }

        // Canon logic
        if (updatedBook.IsCanon && !MyCanon.Contains(updatedBook))
            MyCanon.Add(updatedBook);
        else if (!updatedBook.IsCanon && MyCanon.Contains(updatedBook))
            MyCanon.Remove(updatedBook);

        // Update status-based lists
        UpdateBookStatus(updatedBook, updatedBook.Status);
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
            case BookStatus.DNF:
                TBRBooks.Add(book);
                break;
        }

        if (book.IsCanon && !MyCanon.Contains(book))
            MyCanon.Add(book);
        else if (!book.IsCanon && MyCanon.Contains(book))
            MyCanon.Remove(book);

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
        MyCanon.Remove(book);
    }

    public void AddToCanon(Book book)
    {
        if (!MyCanon.Contains(book))
        {
            book.IsCanon = true;
            MyCanon.Add(book);
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

    public ObservableCollection<Book> GetMyCanon()
    {
        return MyCanon;
    }

    public ObservableCollection<string> GetSubjectsSuggestions() => GetTopSuggestions(_subjectHistory, _defaultSubjects);
    public ObservableCollection<string> GetVibeSuggestions() => GetTopSuggestions(_vibeHistory, _defaultVibes);
    public ObservableCollection<string> GetSourceSuggestions() => GetTopSuggestions(_sourceHistory, _defaultSources);
    public List<string> GetAuthorSuggestions()
    {
        return _authorHistory.Keys
             .Where(k => !string.IsNullOrWhiteSpace(k))
             .OrderByDescending(k => _authorHistory[k])
             .Take(5)
             .ToList();
    }

    public List<string> GetAuthorSuggestions(string input)
    {
        return _authorHistory.Keys
            .Where(k => !string.IsNullOrWhiteSpace(k) && k.StartsWith(input, StringComparison.OrdinalIgnoreCase))
            .OrderByDescending(k => _authorHistory[k])
            .Take(5)
            .ToList();
    }

    public List<string> GetCountrySuggestions()
    {
        return _countryHistory.Keys
        .Where(k => !string.IsNullOrWhiteSpace(k))
        .OrderByDescending(k => _countryHistory[k])
        .Take(5)
        .ToList();
    }

    public List<string> GetCountrySuggestions(string input)
    {
        return _countryHistory.Keys
            .Where(k => !string.IsNullOrWhiteSpace(k) && k.StartsWith(input, StringComparison.OrdinalIgnoreCase))
            .OrderByDescending(k => _countryHistory[k])
            .Take(5)
            .ToList();
    }

    public List<string> GetSubjectsSuggestions(string input) =>
_subjectHistory.Keys
    .Where(k => !string.IsNullOrWhiteSpace(k) && k.StartsWith(input, StringComparison.OrdinalIgnoreCase))
    .OrderByDescending(k => _subjectHistory[k])
    .Take(5)
    .ToList();

    public List<string> GetVibeSuggestions(string input) =>
_vibeHistory.Keys
    .Where(k => !string.IsNullOrWhiteSpace(k) && k.StartsWith(input, StringComparison.OrdinalIgnoreCase))
    .OrderByDescending(k => _vibeHistory[k])
    .Take(5)
    .ToList();

    public List<string> GetSourceSuggestions(string input) =>
_sourceHistory.Keys
    .Where(k => !string.IsNullOrWhiteSpace(k) && k.StartsWith(input, StringComparison.OrdinalIgnoreCase))
    .OrderByDescending(k => _sourceHistory[k])
    .Take(5)
    .ToList();


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

        AddBook(new Book { Title = "The Night Circus", Author = "Erin Morgenstern", YearPublished = 2021, Pages = 183, Country = "Nigeria", Subject = "Technology", Vibe = "Sad", Source = "Social Media", Status = BookStatus.DNF, IsCanon = false });
        AddBook(new Book { Title = "White Teeth", Author = "Zadie Smith", YearPublished = 1963, Pages = 546, Country = "UK", Subject = "Politics", Vibe = "Philosophical", Source = "Social Media", Status = BookStatus.Read, IsCanon = false });
        AddBook(new Book { Title = "The Wind-Up Bird Chronicle", Author = "Haruki Murakami", YearPublished = 1964, Pages = 379, Country = "Nigeria", Subject = "History", Vibe = "Funny", Source = "Podcast", Status = BookStatus.CurrentReads, IsCanon = false });
        AddBook(new Book { Title = "Never Let Me Go", Author = "Kazuo Ishiguro", YearPublished = 1955, Pages = 338, Country = "France", Subject = "Mystery", Vibe = "Tense", Source = "Book Club", Status = BookStatus.Read, IsCanon = true });
        AddBook(new Book { Title = "The Amazing Adventures of Kavalier & Clay", Author = "Michael Chabon", YearPublished = 2000, Pages = 512, Country = "Germany", Subject = "Mystery", Vibe = "Weird", Source = "Gift", Status = BookStatus.Read, IsCanon = false });
        AddBook(new Book { Title = "Midnight's Children", Author = "Salman Rushdie", YearPublished = 2004, Pages = 229, Country = "Chile", Subject = "Politics", Vibe = "Hopeful", Source = "Book Club", Status = BookStatus.Read, IsCanon = true });
        AddBook(new Book { Title = "Cloud Atlas", Author = "David Mitchell", YearPublished = 2014, Pages = 561, Country = "India", Subject = "Love", Vibe = "Dark", Source = "Library", Status = BookStatus.TBR, IsCanon = true });
        AddBook(new Book { Title = "The Brief Wondrous Life of Oscar Wao", Author = "Junot Díaz", YearPublished = 1976, Pages = 558, Country = "Chile", Subject = "Politics", Vibe = "Funny", Source = "Library", Status = BookStatus.CurrentReads, IsCanon = true });
        AddBook(new Book { Title = "Lincoln in the Bardo", Author = "George Saunders", YearPublished = 1988, Pages = 262, Country = "Chile", Subject = "Love", Vibe = "Hopeful", Source = "Library", Status = BookStatus.TBR, IsCanon = false });
        AddBook(new Book { Title = "A Visit from the Goon Squad", Author = "Jennifer Egan", YearPublished = 1998, Pages = 683, Country = "UK", Subject = "Politics", Vibe = "Weird", Source = "Gift", Status = BookStatus.CurrentReads, IsCanon = false });
        AddBook(new Book { Title = "The Sellout", Author = "Paul Beatty", YearPublished = 1964, Pages = 692, Country = "Russia", Subject = "Politics", Vibe = "Dark", Source = "Library", Status = BookStatus.CurrentReads, IsCanon = true });
        AddBook(new Book { Title = "The Luminaries", Author = "Eleanor Catton", YearPublished = 1996, Pages = 535, Country = "Russia", Subject = "History", Vibe = "Beautiful", Source = "Book Club", Status = BookStatus.TBR, IsCanon = false });
        AddBook(new Book { Title = "Normal People", Author = "Sally Rooney", YearPublished = 1999, Pages = 688, Country = "Japan", Subject = "Friendship", Vibe = "Hopeful", Source = "Social Media", Status = BookStatus.CurrentReads, IsCanon = false });
        AddBook(new Book { Title = "The Goldfinch", Author = "Donna Tartt", YearPublished = 2005, Pages = 457, Country = "Russia", Subject = "Mystery", Vibe = "Tense", Source = "Review", Status = BookStatus.CurrentReads, IsCanon = false });
        AddBook(new Book { Title = "The Overstory", Author = "Richard Powers", YearPublished = 1982, Pages = 683, Country = "France", Subject = "Politics", Vibe = "Uplifting", Source = "Review", Status = BookStatus.TBR, IsCanon = false });
        AddBook(new Book { Title = "Circe", Author = "Madeline Miller", YearPublished = 2001, Pages = 258, Country = "Chile", Subject = "Fantasy", Vibe = "Hopeful", Source = "Social Media", Status = BookStatus.Read, IsCanon = false });
        AddBook(new Book { Title = "The Underground Railroad", Author = "Colson Whitehead", YearPublished = 2012, Pages = 313, Country = "Chile", Subject = "Politics", Vibe = "Tense", Source = "Review", Status = BookStatus.Read, IsCanon = true });
        AddBook(new Book { Title = "The Road", Author = "Cormac McCarthy", YearPublished = 1994, Pages = 446, Country = "Germany", Subject = "War", Vibe = "Philosophical", Source = "Social Media", Status = BookStatus.DNF, IsCanon = false });
        AddBook(new Book { Title = "Piranesi", Author = "Susanna Clarke", YearPublished = 1986, Pages = 259, Country = "USA", Subject = "Mystery", Vibe = "Tense", Source = "Podcast", Status = BookStatus.TBR, IsCanon = false });
        AddBook(new Book { Title = "Exit West", Author = "Mohsin Hamid", YearPublished = 1985, Pages = 287, Country = "Russia", Subject = "Fantasy", Vibe = "Weird", Source = "Library", Status = BookStatus.TBR, IsCanon = false });
        AddBook(new Book { Title = "Klara and the Sun", Author = "Kazuo Ishiguro", YearPublished = 1983, Pages = 471, Country = "Japan", Subject = "Adventure", Vibe = "Hopeful", Source = "Library", Status = BookStatus.TBR, IsCanon = false });
        AddBook(new Book { Title = "Sula", Author = "Toni Morrison", YearPublished = 1976, Pages = 352, Country = "India", Subject = "Politics", Vibe = "Hopeful", Source = "Gift", Status = BookStatus.CurrentReads, IsCanon = false });
        AddBook(new Book { Title = "Norwegian Wood", Author = "Haruki Murakami", YearPublished = 2009, Pages = 591, Country = "Nigeria", Subject = "Family", Vibe = "Whimsical", Source = "Review", Status = BookStatus.TBR, IsCanon = false });
        AddBook(new Book { Title = "The Master and Margarita", Author = "Mikhail Bulgakov", YearPublished = 1971, Pages = 547, Country = "India", Subject = "Fantasy", Vibe = "Sad", Source = "Gift", Status = BookStatus.DNF, IsCanon = false });
        AddBook(new Book { Title = "Jazz", Author = "Toni Morrison", YearPublished = 2013, Pages = 240, Country = "Nigeria", Subject = "Mystery", Vibe = "Sad", Source = "Review", Status = BookStatus.CurrentReads, IsCanon = false });
    }

#endif

}
