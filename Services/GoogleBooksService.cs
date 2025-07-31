using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TBRAppMobile.Models;

public class GoogleBooksService
{
    private readonly HttpClient _httpClient = new();

    public async Task<List<Book>> SearchBooksAsync(string query)
    {
        var url = $"https://www.googleapis.com/books/v1/volumes?q={Uri.EscapeDataString(query)}";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var json = JsonDocument.Parse(content);

        var results = new List<Book>();
        if (!json.RootElement.TryGetProperty("items", out var items)) return results;

        foreach (var item in items.EnumerateArray())
        {
            var volumeInfo = item.GetProperty("volumeInfo");

            var title = volumeInfo.GetProperty("title").GetString() ?? "Untitled";

            string author = "N/A";
            if (volumeInfo.TryGetProperty("authors", out var authors) && authors.GetArrayLength() > 0)
            {
                var rawAuthor = authors[0].GetString();
                if (!string.IsNullOrWhiteSpace(rawAuthor))
                    author = rawAuthor;
            }

            var pages = volumeInfo.TryGetProperty("pageCount", out var pagesVal)
                ? pagesVal.GetInt32()
                : 0;

            var year = volumeInfo.TryGetProperty("publishedDate", out var dateVal) &&
                       int.TryParse(dateVal.GetString()?.Substring(0, 4), out var parsedYear)
                ? parsedYear
                : 0;

            string imageUrl = "N/A";
            if (volumeInfo.TryGetProperty("imageLinks", out var links) &&
                links.TryGetProperty("thumbnail", out var img))
            {
                var rawUrl = img.GetString();
                if (!string.IsNullOrWhiteSpace(rawUrl))
                    imageUrl = rawUrl;
            }

            results.Add(new Book
            {
                Title = title,
                Author = author,
                Pages = pages,
                Country = "N/A",
                YearPublished = year,
                IconPath = imageUrl
            });
        }

        return results;
    }

}