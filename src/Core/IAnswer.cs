using System.Reflection;
using System.Runtime.CompilerServices;

namespace Core;

public interface IAnswer<out T>
    where T : IAnswer<T>
{
    static virtual int Year
    {
        get
        {
            var assembly = T.GetAssembly().GetName().Name ?? throw new InvalidOperationException();
            var index = assembly.IndexOf(".Y", StringComparison.Ordinal);

            return int.Parse(assembly.AsSpan().Slice(index + 2, 4));
        }
    }

    static virtual int Day
    {
        get
        {
            var assembly = T.GetAssembly().GetName().Name ?? throw new InvalidOperationException();
            var index = assembly.IndexOf(".D", StringComparison.Ordinal);

            return int.Parse(assembly.AsSpan().Slice(index + 2, 2));
        }
    }

    static virtual Assembly GetAssembly() => typeof(T).Assembly;

    static abstract string TestData { get; }

    static abstract string InputData { get; }

    static abstract int TestAnswerOne { get; }

    static abstract int TestAnswerTwo { get; }

    static abstract int SolveAnswerOne(ReadOnlySpan<char> reader);

    static abstract int SolveAnswerTwo(ReadOnlySpan<char> reader);
}
