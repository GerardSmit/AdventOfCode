namespace Core;

public interface IAnswer
{
    int Year { get; }

    int Day { get; }

    int TestAnswerOne { get; }

    int TestAnswerTwo { get; }

    int? GetAnswerOne(FileSource source);

    int? GetAnswerTwo(FileSource source);
}
