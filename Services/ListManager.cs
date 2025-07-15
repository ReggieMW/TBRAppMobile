using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TBRAppMobile.Models;
using TBRAppMobile.Services;

namespace TBRAppMobile.Services
{
    public class ListManager
    {
        private readonly BookService _bookService;

        public ListManager()
        {
            _bookService = new BookService();

#if DEBUG
            SeedTestBooks();
#endif
        }

        public ObservableCollection<Book> TBR_Books { get; } = new();
        public ObservableCollection<Book> ReadBooks => new(_bookService.GetReadBooks());
        public ObservableCollection<Book> MyCanon => new(_bookService.GetCanonBooks());
        public ObservableCollection<Book> CurrentReads => new(_bookService.GetCurrentReads());

        public void AddBook(Book book)
        {
            _bookService.AddBook(book);
            if (book.Status == BookStatus.TBR)
                TBR_Books.Add(book);

        }

        public void AddReadBook(Book book)
        {
            MarkBookAsRead(book);
        }

        public void AddToCanon(Book book)
        {
            _bookService.AddToCanon(book);
        }

        public void MarkBookAsRead(Book book, string? newVibe = null, string? comparable = null)
        {
            _bookService.MarkAsRead(book, newVibe, comparable);
        }

        public List<string> GetSubjectSuggestions() => _bookService.GetSubjectsSuggestions();
        public List<string> GetVibeSuggestions() => _bookService.GetVibeSuggestions();
        public List<string> GetSourceSuggestions() => _bookService.GetDiscoverSuggestions();

        public List<string> GetTopSubjects()
        {
            return _bookService.GetSubjectsSuggestions();
        }

        public List<string> GetTopVibes()
        {
            return _bookService.GetVibeSuggestions();
        }

        public List<string> GetTopSources()
        {
            return _bookService.GetDiscoverSuggestions();
        }

        private void SeedTestBooks()
        {
            var books = new List<Book>
    {
        new Book
        {
            Title = "Test Book 1",
            Author = "Author A",
            YearPublished = 2001,
            Pages = 320,
            Country = "USA",
            Subject = "Love",
            Vibe = "Hopeful",
            Source = "BookTok"
        },
        new Book
        {
            Title = "Test Book 2",
            Author = "Author B",
            YearPublished = 2015,
            Pages = 450,
            Country = "UK",
            Subject = "History",
            Vibe = "Thoughtful",
            Source = "Review"
        },
        new Book
        {
            Title = "Test Book 3",
            Author = "Author C",
            YearPublished = 2020,
            Pages = 220,
            Country = "Canada",
            Subject = "Murder",
            Vibe = "Scary",
            Source = "Recommended"
        },
        new Book
        {
            Title = "The Cosmic Drift",
            Author = "Ada Holt",
            YearPublished = 1998,
            Pages = 310,
            Country = "USA",
            Subject = "Outer Space",
            Vibe = "Thoughtful",
            Source = "Cool Cover"
        },
        new Book
        {
            Title = "Beneath the Weeping Willow",
            Author = "John Fair",
            YearPublished = 2007,
            Pages = 275,
            Country = "Canada",
            Subject = "Love",
            Vibe = "Sad",
            Source = "Review"
        }
    };

            foreach (var book in books)
            {
                AddBook(book);
            }
        }
    }
}
