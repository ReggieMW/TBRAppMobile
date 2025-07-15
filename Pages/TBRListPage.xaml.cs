using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using TBRAppMobile.Models;
using TBRAppMobile.Services;


namespace TBRAppMobile.Pages;

public partial class TBRListPage : ContentPage
{
    public ObservableCollection<Book> TBRBooks { get; } = new();

    private readonly ListManager _manager;

    public TBRListPage(ListManager manager)
    {
        InitializeComponent();
        _manager = manager;
        TBRListView.ItemsSource = _manager.TBR_Books;
    }

    private async void OnMarkAsReadClicked(object sender, EventArgs e)
{
    var book = (sender as Button)?.BindingContext as Book;

    bool updateVibe = await DisplayAlert("Update Vibe?", "Do you want to update the vibe?", "Yes", "No");
    string? newVibe = null;
    if (updateVibe)
        newVibe = await DisplayPromptAsync("New Vibe", "Enter the book's new vibe:");

    bool recommend = await DisplayAlert("Recommend?", "Did you like this book enough to recommend it?", "Yes", "No");
    string? comparable = null;
    if (recommend)
        comparable = await DisplayPromptAsync("Comparable", "Enter a comparable author or book:");

    _manager.MarkBookAsRead(book, newVibe, comparable);

    await DisplayAlert("Done", $"{book.Title} marked as read.", "OK");
}

}
