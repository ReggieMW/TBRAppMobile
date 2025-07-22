using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TBRAppMobile.Models;
using TBRAppMobile.Services;

namespace TBRAppMobile.ViewModels;

public class BookViewModel : INotifyPropertyChanged
{
    private readonly BookService _bookService;
    private Book _book;

    public BookViewModel(Book book, BookService bookService)
    {
        _book = book;
        _bookService = bookService;

        ToggleCanonCommand = new Command(ToggleCanon);
        UpdateStatusCommand = new Command<BookStatus>(UpdateStatus);
    }

    public Book Book => _book;

    public string Title => _book.Title ?? string.Empty;
    public string Author => _book.Author ?? string.Empty;
    public string Country => _book.Country ?? string.Empty;
    public string Subject => _book.Subject ?? string.Empty;
    public string Vibe => _book.Vibe ?? string.Empty;
    public string Source => _book.Source ?? string.Empty;
    public string ImagePath => _book.IconPath ?? "book_cyan.png";


    public int YearPublished => _book.YearPublished;
    public int Pages => _book.Pages;

    public bool IsNotTBR => Status != BookStatus.TBR;
    public bool IsNotCurrentReads => Status != BookStatus.CurrentReads;
    public bool IsNotRead => Status != BookStatus.Read;
    public bool IsNotDNF => Status != BookStatus.DNF;


public string CanonButtonText => IsCanon ? "✅ Added to Canon" : "Not in Canon";

    public bool IsCanon
    {
        get => _book.IsCanon;
        set
        {
            if (_book.IsCanon != value)
            {
                _book.IsCanon = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanonButtonText));
            }
        }
    }

    public BookStatus Status
    {
        get => _book.Status;
        set
        {
            if (_book.Status != value)
            {
                _book.Status = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsNotTBR));
                OnPropertyChanged(nameof(IsNotCurrentReads));
                OnPropertyChanged(nameof(IsNotRead));
                OnPropertyChanged(nameof(IsNotDNF));
            }
        }
    }

    public ICommand ToggleCanonCommand { get; }
    public ICommand UpdateStatusCommand { get; }

    private void ToggleCanon()
    {
        IsCanon = !IsCanon;
        _bookService.UpdateBook(_book);
    }

    private void UpdateStatus(BookStatus newStatus)
    {
        Status = newStatus;
        _bookService.UpdateBook(_book);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null!) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
