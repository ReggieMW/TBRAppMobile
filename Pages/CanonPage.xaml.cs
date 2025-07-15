using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using TBRAppMobile.Models;
using TBRAppMobile.Services;

namespace TBRAppMobile.Pages;

public partial class CanonPage : ContentPage
{
    public ObservableCollection<Book> CanonBooks { get; } = new();
    private readonly ListManager _manager;

    public CanonPage(ListManager manager)
    {
        InitializeComponent();
        _manager = manager;

        foreach (var book in _manager.MyCanon)
            CanonBooks.Add(book);

        BindingContext = this;
    }
}
