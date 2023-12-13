using System.Text.RegularExpressions;
using AdventOfCode.InputReader;

namespace AdventOfCode.ProblemSolvers._2023.Day12;

public sealed class HotSprings(IReadInputs inputReader) : ProblemSolver(inputReader)
{
    private const string INPUT_FILE_NAME = "InputDay12.txt";
    private static readonly Dictionary<string, long> _cache = [];

    public override long SolvePart1()
    {
        return _inputReader.GetProblemInput(INPUT_FILE_NAME).Sum(GetPossibleArrangements);
    }

    public override long SolvePart2()
    {
        return _inputReader.GetProblemInput(INPUT_FILE_NAME).Select(UnfoldLine).Sum(GetPossibleArrangements);
    }

    public static string UnfoldLine(string record)
    {
        var workingGroups = record.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];
        var springRecord = record.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
        return string.Join('?', Enumerable.Repeat(springRecord, 5)) + ' ' + string.Join(',', Enumerable.Repeat(workingGroups, 5));
    }

    public static long GetPossibleArrangements(string record)
    {
        var workingGroups = record.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1].Split(',').Select(int.Parse).ToList();
        var springRecord = record.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
        if(_cache.TryGetValue(record, out var result))
        {
            return result;
        }
        _cache.Add(record, GetPossibleArrangementsRecursive(springRecord, workingGroups));
        return _cache[record];
    }

    private static long GetPossibleArrangementsRecursive(string springRecord, List<int> workingGroups)
    {
        while (true)
        {
            if (workingGroups.Count == 0)
            {
                return springRecord.Contains('#') ? 0 : 1;
            }

            if (springRecord.Length == 0)
            {
                return 0;
            }

            switch (springRecord[0])
            {
                case '.': springRecord = springRecord.Trim('.'); continue;
                case '?': return GetPossibleArrangements('.' + springRecord[1..] + ' ' + string.Join(',', workingGroups))
                                + GetPossibleArrangements('#' + springRecord[1..] + ' ' + string.Join(',', workingGroups));
                default:
                    if (workingGroups.Count == 0)
                    {
                        return 0;
                    }
                    if (springRecord.Length < workingGroups[0])
                    {
                        return 0;
                    }
                    if (springRecord[..workingGroups[0]].Contains('.'))
                    {
                        return 0;
                    }
                    if (workingGroups.Count > 1)
                    {
                        if (springRecord.Length < workingGroups[0] + 1 || springRecord[workingGroups[0]] == '#')
                        {
                            return 0;
                        }

                        springRecord = springRecord[(workingGroups[0] + 1)..];
                        workingGroups = workingGroups[1..];
                        continue;
                    }
                    springRecord = springRecord[workingGroups[0]..];
                    workingGroups = workingGroups[1..];
                    continue;
            }
        }
    }
}
