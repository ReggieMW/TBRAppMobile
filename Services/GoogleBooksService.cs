using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TBRAppMobile.Models;

public class GoogleBooksService
{
    private readonly HttpClient _httpClient = new();

    public async Task<List<Book?>> SearchBooksAsync(string query)
    {
        var url = $"https://www.googleapis.com/books/v1/volumes?q={Uri.EscapeDataString(query)}";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var json = JsonDocument.Parse(content);

        var results = new List<Book>();
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
        if (!json.RootElement.TryGetProperty("items", out var items)) return results;
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.

        foreach (var item in items.EnumerateArray())
    {
        var volumeInfo = item.GetProperty("volumeInfo");

        var title = volumeInfo.GetProperty("title").GetString() ?? "Untitled";
        var author = volumeInfo.TryGetProperty("authors", out var authors) && authors.GetArrayLength() > 0
                     ? authors[0].GetString()
                     : "Unknown";

        var pages = volumeInfo.TryGetProperty("pageCount", out var pagesVal) ? pagesVal.GetInt32() : 0;

        var year = volumeInfo.TryGetProperty("publishedDate", out var dateVal) &&
                   int.TryParse(dateVal.GetString()?.Substring(0, 4), out var parsedYear)
                   ? parsedYear : 0;

        var imageUrl = volumeInfo.TryGetProperty("imageLinks", out var links) &&
                       links.TryGetProperty("thumbnail", out var img)
                       ? img.GetString() : null;

#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
        results.Add(new Book
        {
            Title = title,
            Author = author,
            Pages = pages,
            YearPublished = year,
            IconPath = imageUrl
        });
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8601 // Possible null reference assignment.
    }

#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
        return results;
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
    }
}