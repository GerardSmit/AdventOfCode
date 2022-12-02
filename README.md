# Advent of Code
This repository contains my solutions to the [Advent of Code](https://adventofcode.com/) puzzles.

## Benchmarks
To run a benchmark:

1. Go to the project (e.g. `cd src/Answers/Y2022.D01`)
2. Run `dotnet run -c Release -- benchmark`

The following benchmarks were run with the following specs:

```
BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.819)
AMD Ryzen 9 5950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=7.0.200
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  ```

Notes on the benchmarks:

1. Test data is added to the assembly as an embedded resource, so it's already loaded in memory when the assembly gets loaded.
2. Getting the stream of the resource results in creating a `ManifestResourceStream`. In total this is 640 bytes.
3. Parsing of the embedded resource is being done in the benchmark (splitting new lines into spans).

### Y2022.D01
|          Method |      Mean |     Error |    StdDev |   Gen0 | Allocated |
|---------------- |----------:|----------:|----------:|-------:|----------:|
|  AnswerOne_Test |  1.125 us | 0.0216 us | 0.0222 us | 0.0381 |     640 B |
| AnswerOne_Input | 21.395 us | 0.0753 us | 0.0705 us | 0.0305 |     640 B |
|  AnswerTwo_Test |  1.087 us | 0.0047 us | 0.0044 us | 0.0381 |     640 B |
| AnswerTwo_Input | 21.700 us | 0.0672 us | 0.0561 us | 0.0305 |     640 B |

### Y2022.D02
|          Method |      Mean |     Error |    StdDev |   Gen0 | Allocated |
|---------------- |----------:|----------:|----------:|-------:|----------:|
|  AnswerOne_Test |  1.053 us | 0.0205 us | 0.0273 us | 0.0381 |     640 B |
| AnswerOne_Input | 53.217 us | 0.5645 us | 0.5004 us |      - |     640 B |
|  AnswerTwo_Test |  1.036 us | 0.0068 us | 0.0064 us | 0.0381 |     640 B |
| AnswerTwo_Input | 60.034 us | 1.0510 us | 0.9831 us |      - |     640 B |