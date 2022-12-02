using Y2022.D02.Model;

namespace Y2022.D02.Utils;

public static class CharUtils
{
    public static Choice ToChoice(char value)
    {
        return value switch
        {
            'A' or 'X' => Choice.Rock,
            'B' or 'Y' => Choice.Paper,
            'C' or 'Z' => Choice.Scissors,
            _ => throw new ArgumentException("Invalid choice", nameof(value))
        };
    }

    public static Result ToResult(char value)
    {
        return value switch
        {
            'X' => Result.Loss,
            'Y' => Result.Draw,
            'Z' => Result.Win,
            _ => throw new ArgumentException("Invalid choice", nameof(value))
        };
    }
}
