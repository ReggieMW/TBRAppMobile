using Microsoft.Maui.Controls;
using TBRAppMobile.Models;

namespace TBRAppMobile.Views
{
    //Class to provide a uniform view of all books for BookViewPage
    public partial class BookCard : ContentView
    {
        public BookCard()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string), typeof(BookCard));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty AuthorProperty =
            BindableProperty.Create(nameof(Author), typeof(string), typeof(BookCard));

        public string Author
        {
            get => (string)GetValue(AuthorProperty);
            set => SetValue(AuthorProperty, value);
        }

        public static readonly BindableProperty IconPathProperty =
            BindableProperty.Create(nameof(IconPath), typeof(string), typeof(BookCard));

        public string IconPath
        {
            get => (string)GetValue(IconPathProperty);
            set => SetValue(IconPathProperty, value);
        }

        public static readonly BindableProperty PagesProperty =
            BindableProperty.Create(nameof(Pages), typeof(int), typeof(BookCard), 0);

        public int Pages
        {
            get => (int)GetValue(PagesProperty);
            set => SetValue(PagesProperty, value);
        }

        public static readonly BindableProperty SubjectProperty =
        BindableProperty.Create(nameof(Subject), typeof(string), typeof(BookCard));
        public string Subject
        {
            get => (string)GetValue(SubjectProperty);
            set => SetValue(SubjectProperty, value);
        }

        public static readonly BindableProperty SourceProperty =
        BindableProperty.Create(nameof(Source), typeof(string), typeof(BookCard));

        public string Source
        {
            get => (string)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public static readonly BindableProperty VibeProperty =
            BindableProperty.Create(nameof(Vibe), typeof(string), typeof(BookCard));

        public string Vibe
        {
            get => (string)GetValue(VibeProperty);
            set => SetValue(VibeProperty, value);
        }

        public static readonly BindableProperty YearPublishedProperty =
        BindableProperty.Create(nameof(YearPublished), typeof(int), typeof(BookCard), 0);

        public int YearPublished
        {
            get => (int)GetValue(YearPublishedProperty);
            set => SetValue(YearPublishedProperty, value);
        }

        public static readonly BindableProperty CountryProperty =
            BindableProperty.Create(nameof(Country), typeof(string), typeof(BookCard));

        public string Country
        {
            get => (string)GetValue(CountryProperty);
            set => SetValue(CountryProperty, value);
        }

        public static readonly BindableProperty StatusProperty =
            BindableProperty.Create(nameof(Status), typeof(BookStatus), typeof(BookCard), defaultValue: BookStatus.TBR);

        public BookStatus Status
        {
            get => (BookStatus)GetValue(StatusProperty);
            set => SetValue(StatusProperty, value);
        }

        public static readonly BindableProperty IsCanonProperty =
        BindableProperty.Create(nameof(IsCanon), typeof(bool), typeof(BookCard), false);

        public bool IsCanon
        {
            get => (bool)GetValue(IsCanonProperty);
            set => SetValue(IsCanonProperty, value);
        }

        public static readonly BindableProperty RecommendProperty =
            BindableProperty.Create(nameof(Recommend), typeof(bool), typeof(BookCard), false);

        public bool Recommend
        {
            get => (bool)GetValue(RecommendProperty);
            set => SetValue(RecommendProperty, value);
        }

        public static readonly BindableProperty ComparableProperty =
            BindableProperty.Create(nameof(Comparable), typeof(string), typeof(BookCard));

        public string Comparable
        {
            get => (string)GetValue(ComparableProperty);
            set => SetValue(ComparableProperty, value);
        }

        public event EventHandler<Book>? StatusChanged;
        public event EventHandler<Book>? RemoveRequested;

//updates for status change
        private void OnStatusChanged(object sender, EventArgs e)
        {
            RecommendSection.IsVisible = Status == BookStatus.Read || Status == BookStatus.DNF;
            StatusChanged?.Invoke(this, GetBook());
        }

//not implemented yet
        private void OnRecommendToggled(object sender, ToggledEventArgs e)
        {
            Recommend = e.Value;
            ComparableEntry.IsVisible = Recommend;
        }

//Remove book option, button not added yet
        private void OnRemoveClicked(object sender, EventArgs e)
        {
            RemoveRequested?.Invoke(this, GetBook());
        }

//fetches book info
        private Book GetBook()
        {
            return new Book
            {
                Title = this.Title,
                Author = this.Author,
                Pages = this.Pages,
                Subject = this.Subject,
                Source = this.Source,
                Vibe = this.Vibe,
                YearPublished = this.YearPublished,
                Country = this.Country,
                Status = this.Status,
                IsCanon = this.IsCanon,
                Recommended = this.Recommend,
                Comparable = this.Recommend ? this.Comparable : null,
                IconPath = this.IconPath
            };
        }
    }
}
