using System.Collections.ObjectModel;


namespace TBRAppMobile.Helpers;

//class to manage suggestion functionality
public static class AutoCompleteManager
{
    public static void FilterSuggestions(
        string input,
        IEnumerable<string> source,
        ObservableCollection<string> target,
        Action<bool> setVisibility)
    {
        target.Clear();

        if (string.IsNullOrWhiteSpace(input))
        {
            setVisibility(false);
            return;
        }

        var matches = source
            .Where(s => s.StartsWith(input, StringComparison.OrdinalIgnoreCase))
            .ToList();

        foreach (var match in matches)
            target.Add(match);

        setVisibility(matches.Any());
    }
}
