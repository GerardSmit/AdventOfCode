namespace Y2022.D02.Model;

public enum Choice
{
    Rock,
    Paper,
    Scissors
}

public static class ChoiceExtensions
{
    public static int GetScoreAgainst(this Choice self, Choice opponent)
    {
        return self.GetWinScoreAgainst(opponent) + GetChoiceScore(self);
    }

    public static int GetWinScoreAgainst(this Choice self, Choice opponent)
    {
        return (self, opponent) switch
        {
            (Choice.Rock, Choice.Paper) => 0,
            (Choice.Rock, Choice.Rock) => 3,
            (Choice.Rock, Choice.Scissors) => 6,

            (Choice.Paper, Choice.Scissors) => 0,
            (Choice.Paper, Choice.Paper) => 3,
            (Choice.Paper, Choice.Rock) => 6,

            (Choice.Scissors, Choice.Rock) => 0,
            (Choice.Scissors, Choice.Scissors) => 3,
            (Choice.Scissors, Choice.Paper) => 6,

            _ => throw new ArgumentException("Invalid choice", nameof(self))
        };
    }

    public static int GetChoiceScore(this Choice choice)
    {
        return choice switch
        {
            Choice.Rock => 1,
            Choice.Paper => 2,
            Choice.Scissors => 3,
            _ => throw new ArgumentException("Invalid choice", nameof(choice))
        };
    }
}
