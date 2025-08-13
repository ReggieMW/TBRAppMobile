using System;
using System.Collections.ObjectModel;
using System.Linq;
using TBRAppMobile.Models;

namespace TBRAppMobile.Services
{
    public static class BookListQuery
    {
        public static ObservableCollection<Book> Apply(
            System.Collections.Generic.IEnumerable<Book> source,
            BookFilter? filter,
            SortField sortField,
            bool ascending)
        {
            var q = source ?? Array.Empty<Book>();

            if (filter is not null)
            {
                if (!string.IsNullOrWhiteSpace(filter.Search))
                {
                    var s = filter.Search.Trim();
                    q = q.Where(b =>
                        (b.Title?.Contains(s, StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (b.Author?.Contains(s, StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (b.Subject?.Contains(s, StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (b.Vibe?.Contains(s, StringComparison.OrdinalIgnoreCase) ?? false));
                }

                if (!string.IsNullOrWhiteSpace(filter.Author))
                    q = q.Where(b => (b.Author ?? "").StartsWith(filter.Author, StringComparison.OrdinalIgnoreCase));

                if (!string.IsNullOrWhiteSpace(filter.Subject))
                    q = q.Where(b => (b.Subject ?? "").StartsWith(filter.Subject, StringComparison.OrdinalIgnoreCase));

                if (!string.IsNullOrWhiteSpace(filter.Vibe))
                    q = q.Where(b => (b.Vibe ?? "").StartsWith(filter.Vibe, StringComparison.OrdinalIgnoreCase));

                if (!string.IsNullOrWhiteSpace(filter.Country))
                    q = q.Where(b => (b.Country ?? "").StartsWith(filter.Country, StringComparison.OrdinalIgnoreCase));

                if (filter.YearMin.HasValue)  q = q.Where(b => b.YearPublished >= filter.YearMin.Value);
                if (filter.YearMax.HasValue)  q = q.Where(b => b.YearPublished <= filter.YearMax.Value);
                if (filter.PagesMin.HasValue) q = q.Where(b => b.Pages >= filter.PagesMin.Value);
                if (filter.PagesMax.HasValue) q = q.Where(b => b.Pages <= filter.PagesMax.Value);

                if (filter.CanonOnly.HasValue)
                    q = filter.CanonOnly.Value ? q.Where(b => b.IsCanon) : q.Where(b => !b.IsCanon);
            }

            q = sortField switch
            {
                SortField.Title         => ascending ? q.OrderBy(b => b.Title)          : q.OrderByDescending(b => b.Title),
                SortField.Author        => ascending ? q.OrderBy(b => b.Author)         : q.OrderByDescending(b => b.Author),
                SortField.YearPublished => ascending ? q.OrderBy(b => b.YearPublished)  : q.OrderByDescending(b => b.YearPublished),
                SortField.Pages         => ascending ? q.OrderBy(b => b.Pages)          : q.OrderByDescending(b => b.Pages),
                SortField.Id            => ascending ? q.OrderBy(b => b.Id)             : q.OrderByDescending(b => b.Id),
                _                       => q
            };


            return new ObservableCollection<Book>(q.ToList());
        }
    }
}
