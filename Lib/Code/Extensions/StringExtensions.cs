using System.Text;

namespace Lib.Code.Extensions;

internal static class StringExtensions
{
    private static readonly char[] LargeSymbols = ['⅛', '¼', '⅓', '½', '⅔', '¾'];

    public static string FormatSymbols(this string text, Temperature temp)
    {
        var builder = new StringBuilder();
        foreach (var word in text.Split(' '))
        {
            if (word.Contains('°'))
            {
                var parts = word.Split('°', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2 && double.TryParse(parts[0], out var value))
                {
                    var unit = parts[1];
                    if (temp == Temperature.Fahrenheit && unit.StartsWith("C", StringComparison.OrdinalIgnoreCase))
                    {
                        builder.Append($"{Math.Round((value * 9 / 5) + 32)}°F");
                    }
                    else if (temp == Temperature.Celsius && unit.StartsWith("F", StringComparison.OrdinalIgnoreCase))
                    {
                        builder.Append($"{Math.Round((value - 32) * 5 / 9)}°C");
                    }
                    else 
                    {
                        builder.Append(word);
                    }
                }
                else
                {
                    builder.Append(word);
                }
            }
            else
            {
                foreach (var c in word)
                {
                    if (LargeSymbols.Contains(c))
                    {
                        builder.Append($"<span style=\"font-size:1.25em;line-height:0;\">{c}</span>");
                    }
                    else
                    {
                        builder.Append(c);
                    }
                }
            }

            builder.Append(' ');
        }

        return builder.ToString().Trim();
    }
}
