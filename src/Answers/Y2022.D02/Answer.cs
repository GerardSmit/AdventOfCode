using Y2022.D02.Model;
using Y2022.D02.Utils;

namespace Y2022.D02;

public class Answer : IAnswer<Answer>
{
    public static int TestAnswerOne => 15;

    public static int TestAnswerTwo => 12;

    public static int SolveAnswerOne(ref SpanReader reader)
    {
        var score = 0;

        foreach (var line in reader)
        {
            if (line.Length < 3) continue;

            var self = CharUtils.ToChoice(line[2]);
            var opponent = CharUtils.ToChoice(line[0]);

            score += self.GetScoreAgainst(opponent);
        }

        return score;
    }

    public static int SolveAnswerTwo(ref SpanReader reader)
    {
        var score = 0;

        foreach (var line in reader)
        {
            if (line.Length < 3) continue;

            var opponent = CharUtils.ToChoice(line[0]);
            var result = CharUtils.ToResult(line[2]);
            var self = result.GetChoiceAgainst(opponent);

            score += self.GetScoreAgainst(opponent);
        }

        return score;
    }
}
