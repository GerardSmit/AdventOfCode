using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace SourceGenerator;

[Generator]
public class DataSourceGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var files = context.AdditionalTextsProvider
            .Where(a => a.Path.EndsWith("input.txt", StringComparison.OrdinalIgnoreCase) ||
                        a.Path.EndsWith("test.txt", StringComparison.OrdinalIgnoreCase))
            .Select((a, c) => (a.Path, a.GetText(c)!.ToString().Trim()));

        var compilationAndFiles = context.CompilationProvider.Combine(files.Collect());
        var options = context.AnalyzerConfigOptionsProvider.Combine(compilationAndFiles);

        context.RegisterSourceOutput(options, Generate);
    }

    private static void Generate(SourceProductionContext context, (AnalyzerConfigOptionsProvider Left, (Compilation Left, ImmutableArray<(string Path, string)> Right) Right) sourceContext)
    {
        var (analyzer, (compilation, files)) = sourceContext;

        if (!analyzer.GlobalOptions.TryGetValue("build_property.RootNamespace", out var ns))
        {
            ns = compilation.AssemblyName;
        }

        foreach (var (path, content) in files)
        {
            var name = path.EndsWith("input.txt", StringComparison.OrdinalIgnoreCase)
                ? "InputData"
                : "TestData";

            var source = $$""""
                namespace {{ns}};

                partial class Answer
                {
                    public static string {{name}} => """
                {{content}}
                """;
                }
                """";

            context.AddSource("Answer." + name + ".cs", source);
        }
    }
}
