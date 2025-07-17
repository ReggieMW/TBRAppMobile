using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TBRAppMobile.Models;
using TBRAppMobile.Services;

namespace TBRAppMobile.ViewModels;

public class BookViewModel : INotifyPropertyChanged
{
    public BookService BookService => _bookService;
    private readonly BookService _bookService;



    public ObservableCollection<Book> TBRBooks { get; set; } = new();
    public ObservableCollection<Book> CurrentReads { get; set; } = new();
    public ObservableCollection<Book> ReadBooks { get; set; } = new();
    public ObservableCollection<Book> DNFBooks { get; set; } = new();

    public BookViewModel(BookService bookService)
    {
        _bookService = bookService;
        LoadBooks();
    }

    private void LoadBooks()
    {
        var allBooks = _bookService.GetAllBooks();

        TBRBooks = new ObservableCollection<Book>(allBooks.Where(b => b.Status == BookStatus.TBR));
        CurrentReads = new ObservableCollection<Book>(allBooks.Where(b => b.Status == BookStatus.CurrentReads));
        ReadBooks = new ObservableCollection<Book>(allBooks.Where(b => b.Status == BookStatus.Read));
        DNFBooks = new ObservableCollection<Book>(allBooks.Where(b => b.Status == BookStatus.DNF));

        OnPropertyChanged(nameof(TBRBooks));
        OnPropertyChanged(nameof(CurrentReads));
        OnPropertyChanged(nameof(ReadBooks));
        OnPropertyChanged(nameof(DNFBooks));
    }

    public void RefreshBooks()
    {
        LoadBooks();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null!) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
