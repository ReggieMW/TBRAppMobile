using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TBRAppMobile.Models;
using TBRAppMobile.Pages;
using TBRAppMobile.Services;
using TBRAppMobile.ViewModels;

//code for viewing a page of an individual book
namespace TBRAppMobile.ViewModels;

public class BookViewModel : INotifyPropertyChanged
{
    private readonly BookService _bookService;
    private Book _book;


    public ICommand ToggleCanonCommand { get; }
    public ICommand UpdateStatusCommand { get; }
    
    public BookViewModel(Book book, BookService bookService)
    {
        _book = book;
        _bookService = bookService;

        //allows user to change book status
        UpdateStatusCommand = new Command<string>(status =>
        {
            if (Enum.TryParse(status, out BookStatus parsedStatus))
                UpdateStatus(parsedStatus);
        });

        ToggleCanonCommand = new Command(ToggleCanonStatus);
    }

    //allows user to add to MyCanon 
    private void ToggleCanonStatus()
    {
        if (Book.IsCanon)
        {
            Book.IsCanon = false;
            _bookService.MyCanon.Remove(Book);
        }
        else
        {
            Book.IsCanon = true;
            if (!_bookService.MyCanon.Contains(Book))
                _bookService.MyCanon.Add(Book);
        }

        _bookService.UpdateBook(Book);

        OnPropertyChanged(nameof(IsCanon));
        OnPropertyChanged(nameof(CanonButtonText));

    }




    //instantiating book properties to allow update methods to function
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

    public bool IsNotTBR => Book?.Status != BookStatus.TBR;
    public bool IsNotRead => Book?.Status != BookStatus.Read;
    public bool IsNotCurrentReads => Book?.Status != BookStatus.CurrentReads;
    public bool IsNotDNF => Book?.Status != BookStatus.DNF;



    public string CanonButtonText => IsCanon ? "✅ Added to Canon" : "Not in Canon";

    //method for adding to canon
    public bool IsCanon
    {
        get => _book.IsCanon;
        set
        {
            if (_book.IsCanon != value)
            {
                _book.IsCanon = value;
                OnPropertyChanged(nameof(CanonButtonText));
                OnPropertyChanged(nameof(IsCanon));
            }
        }
    }

    //method for changing book status
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

    //updates status across app, updates UI
    private void UpdateStatus(BookStatus newStatus)
    {
        if (Book.Status != newStatus)
        {
            Book.Status = newStatus;
            _bookService.UpdateBook(Book);
            OnPropertyChanged(nameof(Book));
            OnPropertyChanged(nameof(IsNotTBR));
            OnPropertyChanged(nameof(IsNotRead));
            OnPropertyChanged(nameof(IsNotCurrentReads));
            OnPropertyChanged(nameof(IsNotDNF));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null!) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
