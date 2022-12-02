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

1. Test data is added to the assembly as an string through a source generator.
2. Parsing of the string is being done in the benchmark (splitting new lines into spans).

### Y2022.D01
|          Method |        Mean |     Error |    StdDev | Allocated |
|---------------- |------------:|----------:|----------:|----------:|
|  AnswerOne_Test |    243.4 ns |   4.02 ns |   3.76 ns |         - |
| AnswerOne_Input | 38,274.9 ns | 257.42 ns | 228.20 ns |         - |
|  AnswerTwo_Test |    248.2 ns |   1.11 ns |   1.04 ns |         - |
| AnswerTwo_Input | 39,512.1 ns | 187.76 ns | 175.63 ns |         - |

### Y2022.D02
|          Method |         Mean |      Error |     StdDev | Allocated |
|---------------- |-------------:|-----------:|-----------:|----------:|
|  AnswerOne_Test |     76.79 ns |   0.799 ns |   0.708 ns |         - |
| AnswerOne_Input | 75,168.08 ns | 629.763 ns | 491.678 ns |         - |
|  AnswerTwo_Test |     88.47 ns |   1.313 ns |   1.228 ns |         - |
| AnswerTwo_Input | 84,879.77 ns | 858.142 ns | 802.707 ns |         - |