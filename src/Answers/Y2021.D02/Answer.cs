namespace Y2021.D02;

public class Answer : IAnswer<Answer>
{
    public static int TestAnswerOne => 150;

    public static int TestAnswerTwo => 900;

    public static int SolveAnswerOne(ref SpanReader lines)
    {
        var horizontal = 0;
        var depth = 0;

        foreach (var line in lines)
        {
            if (!line.TrySplit(' ', out var direction, out var valueStr) ||
                !int.TryParse(valueStr, out var value))
            {
                continue;
            }

            switch (direction)
            {
                case "forward":
                    horizontal += value;
                    break;
                case "down":
                    depth += value;
                    break;
                case "up":
                    depth -= value;
                    break;
            }
        }

        return horizontal * depth;
    }

    public static int SolveAnswerTwo(ref SpanReader lines)
    {
        var horizontal = 0;
        var depth = 0;
        var aim = 0;

        foreach (var line in lines)
        {
            if (!line.TrySplit(' ', out var direction, out var valueStr) ||
                !int.TryParse(valueStr, out var value))
            {
                continue;
            }

            switch (direction)
            {
                case "forward":
                    horizontal += value;
                    depth += aim * value;
                    break;
                case "down":
                    aim += value;
                    break;
                case "up":
                    aim -= value;
                    break;
            }
        }

        return horizontal * depth;
    }
}
