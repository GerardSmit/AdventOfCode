using System.Reflection;

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

    static virtual Stream GetResourceStream(FileSource source)
    {
        var assembly = T.GetAssembly();
        var assemblyName = assembly.GetName().Name;
        var fileName = source switch
        {
            FileSource.Input => "input",
            FileSource.Test => "test",
            _ => throw new ArgumentOutOfRangeException(nameof(source), source, null)
        };

        var resourceName = $"{assemblyName}.Data.{fileName}.txt";
        var stream = assembly.GetManifestResourceStream(resourceName);

        if (stream == null)
        {
            throw new FileNotFoundException($"Resource {resourceName} not found");
        }

        return stream;
    }

    static abstract int TestAnswerOne { get; }

    static abstract int TestAnswerTwo { get; }

    static abstract int SolveAnswerOne(ref SpanReader reader);

    static abstract int SolveAnswerTwo(ref SpanReader reader);
}
