using Xunit;

namespace AdventOfCode;

public class Answer
{
    /// <summary>
    /// Contains all the answers to the Advent of Code puzzles.
    /// </summary>
    public static readonly IReadOnlyList<IAnswer> All = new IAnswer[]
    {
        // 2021
        new Answer<Y2021.D01.Answer>(),
        new Answer<Y2021.D02.Answer>(),
        new Answer<Y2021.D03.Answer>(),

        // 2022
        new Answer<Y2022.D01.Answer>(),
        new Answer<Y2022.D02.Answer>()
    };

    public static IEnumerable<object[]> GetAnswers() => All.Select(a => new object[] { a });

    [Theory]
    [MemberData(nameof(GetAnswers))]
    public void Test(IAnswer answer)
    {
        Assert.Equal(answer.TestAnswerOne, answer.GetAnswerOne(FileSource.Test));
        Assert.Equal(answer.TestAnswerTwo, answer.GetAnswerTwo(FileSource.Test));
    }
}
