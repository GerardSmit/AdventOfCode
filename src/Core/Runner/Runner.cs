using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Running;

namespace Core;

public static class Runner
{
    [ExcludeFromCodeCoverage]
    public static void Run<T>()
        where T : IAnswer<T>
    {
        var args = Environment.GetCommandLineArgs();

        if (args.Any(i => i == "benchmark"))
        {
            BenchmarkRunner.Run<Benchmark<T>>();
        }
        else
        {
            Console.WriteLine($"Year: {T.Year}, Day: {T.Day}");

            var testAnswerOne = GetAnswerOne<T>(FileSource.Test);
            var inputAnswerOne = GetAnswerOne<T>(FileSource.Input);
            var testAnswerTwo = GetAnswerTwo<T>(FileSource.Test);
            var inputAnswerTwo = GetAnswerTwo<T>(FileSource.Input);

            var expectedAnswerOne = T.TestAnswerOne;
            var expectedAnswerTwo = T.TestAnswerTwo;

            Console.WriteLine();
            Console.WriteLine("== Test ==");
            Console.WriteLine($"Answer One  : {testAnswerOne}");

            if (testAnswerOne != expectedAnswerOne)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"   Expected : {expectedAnswerOne}");
                Console.ResetColor();
            }

            Console.WriteLine($"Answer Two  : {testAnswerTwo}");

            if (testAnswerTwo != expectedAnswerTwo)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"   Expected : {expectedAnswerTwo}");
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.WriteLine("== Input ==");
            Console.WriteLine($"Answer One : {inputAnswerOne}");
            Console.WriteLine($"Answer Two : {inputAnswerTwo}");
        }
    }

    public static int? GetAnswerOne<T>(FileSource source)
        where T : IAnswer<T>
    {
        try
        {
            using var stream = T.GetResourceStream(source);
            Span<byte> byteData = stackalloc byte[1024];
            Span<char> charData = stackalloc char[4096];
            var reader = new SpanReader(stream, byteData, charData);

            return T.SolveAnswerOne(ref reader);
        }
        catch (NotImplementedException)
        {
            return null;
        }
        catch (FileNotFoundException)
        {
            return null;
        }
    }

    public static int? GetAnswerTwo<T>(FileSource source)
        where T : IAnswer<T>
    {
        try
        {
            using var stream = T.GetResourceStream(source);
            Span<byte> byteData = stackalloc byte[1024];
            Span<char> charData = stackalloc char[4096];
            var reader = new SpanReader(stream, byteData, charData);

            return T.SolveAnswerTwo(ref reader);
        }
        catch (NotImplementedException)
        {
            return null;
        }
        catch (FileNotFoundException)
        {
            return null;
        }
    }
}
