using TBRAppMobile.Models;

namespace TBRAppMobile.Models;

public class Book
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int YearPublished { get; set; }
    public int Pages { get; set; }
    public string? Country { get; set; } = string.Empty;
    public string? Subject { get; set; } = string.Empty;
    public string? Vibe { get; set; } = string.Empty;
    public string? Source { get; set; } = string.Empty;

    public string? Comparable { get; set; }
    public BookStatus Status { get; set; }
    public bool IsCanon { get; set; }

    public bool Recommended { get; set; }

    private static readonly string[] DefaultIcons =
{
    "book_alloy.png",
    "book_red.png",
    "boook_green.png",
    "book_yellow.png",
    "book_purple.png",
    "book_darkgreen.png",
    "book_black.png",
    "book_cyan.png"
};

private string? _iconPath;
public string IconPath
{
    get => _iconPath ?? _defaultIcon;
    set => _iconPath = value;
}

private readonly string _defaultIcon = DefaultIcons[new Random().Next(DefaultIcons.Length)];

}
