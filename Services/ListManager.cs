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
        public ObservableCollection<Book> MyCanon => new(_bookService.GetCanonBooks());
        public ObservableCollection<Book> CurrentReads => new(_bookService.GetCurrentReads());

        public void AddBook(Book book)
        {
            book.Status = BookStatus.TBR;
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

        public void MoveBookToStatus(Book book, BookStatus newStatus)
        {

            TBR_Books.Remove(book);
            CurrentReads.Remove(book);
            ReadBooks.Remove(book);


            book.Status = newStatus;


            switch (newStatus)
            {
                case BookStatus.TBR:
                case BookStatus.DNF:
                    if (!TBR_Books.Contains(book))
                        TBR_Books.Add(book);
                    break;

                case BookStatus.CurrentReads:
                    if (!CurrentReads.Contains(book))
                        CurrentReads.Add(book);
                    break;

                case BookStatus.Read:
                    if (!ReadBooks.Contains(book))
                        ReadBooks.Add(book);
                    break;
            }

            if (book.IsCanon && !MyCanon.Contains(book))
                MyCanon.Add(book);
            else if (!book.IsCanon && MyCanon.Contains(book))
                MyCanon.Remove(book);
        }
    }
}
