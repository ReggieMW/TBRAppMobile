using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using TBRAppMobile.Models;
using TBRAppMobile.Services;

namespace TBRAppMobile.Pages;

public partial class ReadListPage : ContentPage
{
    public ObservableCollection<Book> ReadBooks { get; } = new();
    private readonly ListManager _manager;

    public ReadListPage(ListManager manager)
    {
        InitializeComponent();
        _manager = manager;
        BindingContext = this;
    }

    private void OnAddToCanonClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Book book)
        {
            _manager.AddToCanon(book);
            DisplayAlert("Added", $"📘 \"{book.Title}\" added to Canon!", "OK");
        }
    }
}
