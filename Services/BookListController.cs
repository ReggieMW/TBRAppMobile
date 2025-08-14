using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using TBRAppMobile.Models;
using TBRAppMobile.Views;

namespace TBRAppMobile.Services
{
    public sealed class BookListController : IDisposable
    {
        private readonly BookService _svc;
        private BookListController? _controller;
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

        // 1) expose the active filter for pages to tweak
        public BookFilter Filter => _filter;

        // 2) convenience setters for chip clicks
        public void SetSubject(string? subject) { _filter.Subject = subject; Refresh(); }
        public void SetVibe(string? vibe) { _filter.Vibe = vibe; Refresh(); }
        public void SetCountry(string? country) { _filter.Country = country; Refresh(); }
        public void SetSource(string? source) { _filter.Source = source; Refresh(); }

        public void SetExactYear(int year)
        {
            _filter.YearMin = year;
            _filter.YearMax = year;
            Refresh();
        }

        public void SetExactPages(int pages)
        {
            _filter.PagesMin = pages;
            _filter.PagesMax = pages;
            Refresh();
        }

        private void OnChipClicked(object sender, ChipClickedEventArgs e)
        {
            if (_controller is null) return;

            switch (e.Type)
            {
                case "Subject": _controller.SetSubject(e.Value); break;
                case "Vibe": _controller.SetVibe(e.Value); break;
                case "Country": _controller.SetCountry(e.Value); break;
                case "Source": _controller.SetSource(e.Value); break;
                case "Year":
                    if (int.TryParse(e.Value, out var y)) _controller.SetExactYear(y);
                    break;
                case "Pages":
                    if (int.TryParse(e.Value, out var p)) _controller.SetExactPages(p);
                    break;
            }
        }

        // In BookListController.cs
        public void SetSubjectOnly(string subject)
        {
            ClearFiltersInternal();
            _filter.Subject = subject;
            Refresh();
        }
        public void SetVibeOnly(string vibe)
        {
            ClearFiltersInternal();
            _filter.Vibe = vibe;
            Refresh();
        }
        public void SetCountryOnly(string country)
        {
            ClearFiltersInternal();
            _filter.Country = country;
            Refresh();
        }
        public void SetExactYearOnly(int year)
        {
            ClearFiltersInternal();
            _filter.YearMin = year;
            _filter.YearMax = year;
            Refresh();
        }
        public void SetExactPagesOnly(int pages)
        {
            ClearFiltersInternal();
            _filter.PagesMin = pages;
            _filter.PagesMax = pages;
            Refresh();
        }

        public void SetAuthorOnly(string author)
        {
            ClearFiltersInternal();
            _filter.Author = author;
            Refresh();
        }

        public void SetSourceOnly(string source)
        {
            ClearFiltersInternal();
            _filter.Source = source;
            if (_searchEntry.Text?.Length > 0) _searchEntry.Text = string.Empty;
            Refresh();
        }

        public void ClearFilters()
        {
            ClearFiltersInternal();
            // Clear the search box UI too
            if (_searchEntry.Text?.Length > 0) _searchEntry.Text = string.Empty;
            Refresh();
        }

        private void ClearFiltersInternal()
        {
            _filter.Search = null;
            _filter.Author = null;
            _filter.Subject = null;
            _filter.Vibe = null;
            _filter.Source = null;
            _filter.Country = null;
            _filter.YearMin = null;
            _filter.YearMax = null;
            _filter.PagesMin = null;
            _filter.PagesMax = null;
            _filter.CanonOnly = null;
        }

        public void Dispose()
        {
            _sortPicker.SelectedIndexChanged -= OnSortChanged;
            _ascSwitch.Toggled -= OnSortChanged;
            _searchEntry.TextChanged -= OnSearchChanged;
        }
    }
}
