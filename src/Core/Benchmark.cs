using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;

namespace Core;

[MemoryDiagnoser]
[ExcludeFromCodeCoverage]
public class Benchmark<T>
    where T : IAnswer<T>
{
    [Benchmark]
    public int? AnswerOne_Test() => Runner.GetAnswerOne<T>(FileSource.Test);

    [Benchmark]
    public int? AnswerOne_Input() => Runner.GetAnswerOne<T>(FileSource.Input);

    [Benchmark]
    public int? AnswerTwo_Test() => Runner.GetAnswerTwo<T>(FileSource.Test);

    [Benchmark]
    public int? AnswerTwo_Input() => Runner.GetAnswerTwo<T>(FileSource.Input);
}
