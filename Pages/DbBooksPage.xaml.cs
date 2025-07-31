using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using TBRAppMobile.Models;

namespace TBRAppMobile.Pages;

public partial class DbBooksPage : ContentPage
{
    public ObservableCollection<Book> Books { get; set; } = new();

    public DbBooksPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        Books.Clear();

        var books = await App.Database.GetBooksAsync();
        foreach (var book in books)
            Books.Add(book);
    }
}
