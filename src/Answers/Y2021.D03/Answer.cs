namespace Y2021.D03;

public partial class Answer : IAnswer<Answer>
{
    public static int TestAnswerOne => 198;

    public static int TestAnswerTwo => 230;

    public static int SolveAnswerOne(ReadOnlySpan<char> span)
    {
        Span<int> zeroBits = stackalloc int[32];
        Span<int> oneBits = stackalloc int[32];

        var length = ParseBits(span, ref oneBits, ref zeroBits);

        // Convert to decimals
        var epsilonRate = 0;
        var gammaRate = 0;

        for (var i = 0; i < length; i++)
        {
            epsilonRate <<= 1;
            gammaRate <<= 1;

            if (zeroBits[i] > oneBits[i])
            {
                epsilonRate |= 1;
            }
            else
            {
                gammaRate |= 1;
            }
        }

        return gammaRate * epsilonRate;
    }

    public static int SolveAnswerTwo(ReadOnlySpan<char> span)
    {
        var oxygenRating = FindDecimal(span, '1', '0');
        var scrubberRating = FindDecimal(span, '0', '1');

        return oxygenRating * scrubberRating;
    }

    private static int FindDecimal(ReadOnlySpan<char> lines, char trueChar, char falseChar)
    {
        var list = lines.ToList();
        var length = list[0].Length;

        for (var i = 0; i < length; i++)
        {
            var zeroBits = 0;
            var oneBits = 0;

            foreach (var line in list)
            {
                if (line[i] == '1')
                {
                    oneBits++;
                }
                else
                {
                    zeroBits++;
                }
            }

            var filterChar = oneBits >= zeroBits ? trueChar : falseChar;
            var firstValue = list[0];

            list.RemoveAll(s => s[i] != filterChar);

            if (list.Count == 0)
            {
                return ParseDecimal(firstValue);
            }
        }

        return ParseDecimal(list[0]);
    }


    private static int ParseDecimal(ReadOnlySpan<char> data)
    {
        var result = 0;

        foreach (var c in data)
        {
            result <<= 1;
            result |= c == '1' ? 1 : 0;
        }

        return result;
    }

    private static int ParseBits(ReadOnlySpan<char> lines, ref Span<int> oneBits, ref Span<int> zeroBits)
    {
        int? length = null;

        // Get all bits
        foreach (var line in lines.EnumerateLines())
        {
            // Find the length of the line
            length ??= line.Length;

            // Parse the bits
            if (line.Length < length) continue;

            for (var i = 0; i < length; i++)
            {
                if (line[i] == '1')
                {
                    oneBits[i]++;
                }
                else
                {
                    zeroBits[i]++;
                }
            }
        }

        return length ?? throw new InvalidOperationException("No data found");
    }
}
