using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        }

        public ObservableCollection<Book> TBR_Books => new(_bookService.GetReadBooks());
        public ObservableCollection<Book> ReadBooks => new(_bookService.GetReadBooks());
        public ObservableCollection<Book> MyCanon => new(_bookService.GetMyCanon());
        public ObservableCollection<Book> CurrentReads => new(_bookService.GetCurrentReads());

        public void AddToCanon(Book book)
        {
            _bookService.AddToCanon(book);
        }

        public ObservableCollection<string> GetSubjectSuggestions() => _bookService.GetSubjectsSuggestions();
        public ObservableCollection<string> GetVibeSuggestions() => _bookService.GetVibeSuggestions();
        public ObservableCollection<string> GetSourceSuggestions() => _bookService.GetSourceSuggestions();

        public ObservableCollection<string> GetTopSubjects()
        {
            return _bookService.GetSubjectsSuggestions();
        }

        public ObservableCollection<string> GetTopVibes()
        {
            return _bookService.GetVibeSuggestions();
        }

        public ObservableCollection<string> GetTopSources()
        {
            return _bookService.GetSourceSuggestions();
        }
    }
}
