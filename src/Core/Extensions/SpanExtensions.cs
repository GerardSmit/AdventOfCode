using System.Diagnostics.CodeAnalysis;

namespace Core;

public static class StringExtensions
{
    public static int ToInt32(this ReadOnlySpan<char> input)
    {
        var value = 0;

        foreach (var c in input)
        {
            value = value * 10 + (c - '0');
        }

        return value;
    }

    public static List<string> ToList(this ReadOnlySpan<char> span)
    {
        var list = new List<string>(1000);

        foreach (var line in span.EnumerateLines())
        {
            list.Add(line.ToString());
        }

        return list;
    }

    public static bool TrySplit(this ReadOnlySpan<char> span, char value, out ReadOnlySpan<char> left, out ReadOnlySpan<char> right)
    {
        var start = span.IndexOf(value);

        if (start == -1)
        {
            left = default;
            right = default;
            return false;
        }

        left = span.Slice(0, start);
        right = span.Slice(start + 1);
        return true;
    }
}
