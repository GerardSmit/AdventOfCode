using System.Text;

namespace Y2022.D03;

public partial class Answer : IAnswer<Answer>
{
    public static int TestAnswerOne => 157;

    public static int TestAnswerTwo => 70;

    public static int SolveAnswerOne(ReadOnlySpan<char> reader)
    {
        var sum = 0;

        foreach (var line in reader.EnumerateLines())
        {
            var duplicateChar = FindDuplicateCharacter(line);

            sum += GetPriority(duplicateChar);
        }

        return sum;
    }

    public static int SolveAnswerTwo(ReadOnlySpan<char> reader)
    {
        var enumerator = reader.EnumerateLines();
        var sum = 0;

        while (FindDuplicateCharacter(ref enumerator, 3) is {} c)
        {
            sum += GetPriority(c);
        }

        return sum;
    }

    private static int GetPriority(char c)
    {
        return c switch
        {
            >= 'a' and <= 'z' => c - 'a' + 1,
            >= 'A' and <= 'Z' => c - 'A' + 27,
            _ => 0
        };
    }

    private static char FindDuplicateCharacter(ReadOnlySpan<char> line)
    {
        Span<bool> chars = stackalloc bool[256];

        var length = line.Length;
        var left = line.Slice(0, length / 2);
        var right = line.Slice(length / 2);

        foreach (var c in left)
        {
            chars[c] = true;
        }

        foreach (var c in right)
        {
            if (chars[c])
            {
                return c;
            }
        }

        throw new InvalidOperationException();
    }

    private static char? FindDuplicateCharacter(ref SpanLineEnumerator enumerator, int lineCount)
    {
        Span<bool> foundChars = stackalloc bool[256];
        Span<int> chars = stackalloc int[256];

        for (var i = 0; enumerator.MoveNext() && i < lineCount; i++)
        {
            foundChars.Clear();

            foreach (var c in enumerator.Current)
            {
                if (foundChars[c])
                {
                    continue;
                }

                foundChars[c] = true;

                if (++chars[c] == lineCount)
                {
                    return c;
                }
            }
        }

        return null;
    }
}
