namespace Y2022.D02.Model;

public enum Result
{
    Win,
    Draw,
    Loss
}

public static class ResultExtensions
{
    public static Choice GetChoiceAgainst(this Result result, Choice opponent)
    {
        return (result, opponent) switch
        {
            (Result.Win, Choice.Rock) => Choice.Paper,
            (Result.Win, Choice.Paper) => Choice.Scissors,
            (Result.Win, Choice.Scissors) => Choice.Rock,

            (Result.Draw, Choice.Rock) => Choice.Rock,
            (Result.Draw, Choice.Paper) => Choice.Paper,
            (Result.Draw, Choice.Scissors) => Choice.Scissors,

            (Result.Loss, Choice.Rock) => Choice.Scissors,
            (Result.Loss, Choice.Paper) => Choice.Rock,
            (Result.Loss, Choice.Scissors) => Choice.Paper,

            _ => throw new ArgumentException("Invalid choice", nameof(result))
        };
    }
}
