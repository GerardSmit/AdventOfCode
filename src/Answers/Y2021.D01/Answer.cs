namespace Y2021.D01;

public class Answer : IAnswer<Answer>
{
    public static int TestAnswerOne => 7;

    public static int TestAnswerTwo => 5;

    public static int SolveAnswerOne(ref SpanReader reader)
    {
        var increase = 0;
        int? lastValue = null;

        foreach (var line in reader)
        {
            if (line.Length == 0) continue;

            var value = line.ToInt32();

            if (value > lastValue)
            {
                increase++;
            }

            lastValue = value;
        }

        return increase;
    }

    public static int SolveAnswerTwo(ref SpanReader reader)
    {
        int? window2 = null;
        int? window3 = null;

        var increase = 0;
        int? lastValue = null;

        foreach (var line in reader)
        {
            if (line.Length == 0) continue;

            var current = line.ToInt32();

            // Move windows
            var window1 = window2;
            window2 = window3;
            window3 = current;

            // Check if the current value is greater than the last value
            var value = window1 + window2 + window3;

            if (value > lastValue)
            {
                increase++;
            }

            lastValue = value;
        }

        return increase;
    }
}
