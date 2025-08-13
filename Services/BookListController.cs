using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using TBRAppMobile.Models;

namespace TBRAppMobile.Services
{
    public sealed class BookListController : IDisposable
    {
        private readonly BookService _svc;
        private readonly Func<ObservableCollection<Book>> _sourceFn;
        private readonly CollectionView _list;
        private readonly Picker _sortPicker;
        private readonly Switch _ascSwitch;
        private readonly Entry _searchEntry;

        private readonly BookFilter _filter = new();
        private SortField _sort = SortField.Title;
        private bool _ascending = true;

        public BookListController(
            BookService svc,
            Func<ObservableCollection<Book>> sourceProvider,
            CollectionView list,
            Picker sortPicker,
            Switch ascSwitch,
            Entry searchEntry)
        {
            _svc = svc;
            _sourceFn = sourceProvider;
            _list = list;
            _sortPicker = sortPicker;
            _ascSwitch = ascSwitch;
            _searchEntry = searchEntry;

            // defaults
            _sortPicker.SelectedIndex = 0; // Title
            _ascSwitch.IsToggled = true;

            // wire events
            _sortPicker.SelectedIndexChanged += OnSortChanged;
            _ascSwitch.Toggled += OnSortChanged;
            _searchEntry.TextChanged += OnSearchChanged;
        }

        public void Refresh()
        {
            var source = _sourceFn(); // page-specific list
            _list.ItemsSource = BookListQuery.Apply(source, _filter, _sort, _ascending);
        }

        private void OnSortChanged(object? s, EventArgs e)
        {
            var txt = (_sortPicker.SelectedItem as string) ?? "Title";
            _sort = Enum.TryParse<SortField>(txt, out var f) ? f : SortField.Title;
            _ascending = _ascSwitch.IsToggled;
            Refresh();
        }

        private void OnSearchChanged(object? s, TextChangedEventArgs e)
        {
            _filter.Search = string.IsNullOrWhiteSpace(e.NewTextValue) ? null : e.NewTextValue;
            Refresh();
        }

        public void Dispose()
        {
            _sortPicker.SelectedIndexChanged -= OnSortChanged;
            _ascSwitch.Toggled -= OnSortChanged;
            _searchEntry.TextChanged -= OnSearchChanged;
        }
    }
}
