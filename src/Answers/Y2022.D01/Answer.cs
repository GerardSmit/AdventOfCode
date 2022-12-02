namespace Y2022.D01;

public class Answer : IAnswer<Answer>
{
    public static int TestAnswerOne => 24000;

    public static int TestAnswerTwo => 45000;

    public static int SolveAnswerOne(ref SpanReader reader)
    {
        var maxValue = 0;
        var current = 0;

        foreach(var line in reader)
        {
            if (line.Length > 0)
            {
                current += line.ToInt32();
                continue;
            }

            if (current > maxValue)
            {
                maxValue = current;
            }

            current = 0;
        }

        return maxValue;
    }

    public static int SolveAnswerTwo(ref SpanReader reader)
    {
        var max1 = 0;
        var max2 = 0;
        var max3 = 0;

        var current = 0;

        foreach(var line in reader)
        {
            if (line.Length > 0)
            {
                current += line.ToInt32();
                continue;
            }

            if (current > max1)
            {
                max3 = max2;
                max2 = max1;
                max1 = current;
            }
            else if (current > max2)
            {
                max3 = max2;
                max2 = current;
            }
            else if (current > max3)
            {
                max3 = current;
            }

            current = 0;
        }

        return max1 + max2 + max3;
    }
}
