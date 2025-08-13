namespace TBRAppMobile.Models
{
    public class BookFilter
    {
        // Text search across title/author/subject/vibe (case-insensitive)
        public string? Search { get; set; }

        // Exact or starts-with filters (you can expand to lists later)
        public string? Author { get; set; }
        public string? Subject { get; set; }
        public string? Vibe { get; set; }
        public string? Country { get; set; }

        // Ranges (inclusive)
        public int? YearMin { get; set; }
        public int? YearMax { get; set; }
        public int? PagesMin { get; set; }
        public int? PagesMax { get; set; }
        public bool? CanonOnly { get; set; }
    }
}
