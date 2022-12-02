namespace Core;

public class Answer<T> : IAnswer
    where T : IAnswer<T>
{
    public int Year => T.Year;

    public int Day => T.Day;

    public int TestAnswerOne => T.TestAnswerOne;

    public int TestAnswerTwo => T.TestAnswerTwo;

    public int? GetAnswerOne(FileSource source) => Runner.GetAnswerOne<T>(source);

    public int? GetAnswerTwo(FileSource source) => Runner.GetAnswerTwo<T>(source);

    public override string ToString()
    {
        return $"Y{Year}.D{Day}";
    }
}
