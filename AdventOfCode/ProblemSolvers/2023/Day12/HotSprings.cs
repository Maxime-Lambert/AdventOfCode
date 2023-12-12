using AdventOfCode.InputReader;

namespace AdventOfCode.ProblemSolvers._2023.Day12;

public sealed class HotSprings(IReadInputs inputReader) : ProblemSolver(inputReader)
{
    private const string INPUT_FILE_NAME = "InputDay12.txt";

    public override long SolvePart1()
    {
        return _inputReader.GetProblemInput(INPUT_FILE_NAME).Sum(GetPossibleArrangements);
    }

    public override long SolvePart2()
    {
        return 0;
    }

    public static int GetPossibleArrangements(string record)
    {
        var workingGroups = record.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1].Split(',').Select(int.Parse).ToList();
        var springRecord = record.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
        return GetPossibleArrangementsRecursive(springRecord, workingGroups, 0);
    }

    private static int GetPossibleArrangementsRecursive(string springRecord, List<int> workingGroups, int workingSpringCounter)
    {
        if (springRecord.Length == 0)
        {
            if (IsRecordPossible(workingGroups, workingSpringCounter))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        switch (springRecord[0])
        {
            case '.':
                if (IsRecordNotPossibleAnymore(workingGroups, workingSpringCounter))
                {
                    return 0;
                }
                if (FoundNextWorkingGroup(workingGroups, workingSpringCounter))
                {
                    return GetPossibleArrangementsRecursive(springRecord[1..], workingGroups.Skip(1).ToList(), 0);
                }
                return GetPossibleArrangementsRecursive(springRecord[1..], workingGroups, 0);
            case '#': return GetPossibleArrangementsRecursive(springRecord[1..], workingGroups, workingSpringCounter + 1);
            default:
                return GetPossibleArrangementsRecursive('.' + springRecord[1..], workingGroups, workingSpringCounter) +
                             GetPossibleArrangementsRecursive('#' + springRecord[1..], workingGroups, workingSpringCounter);
        }
    }

    private static bool FoundNextWorkingGroup(List<int> workingGroups, int workingSpringCounter)
    {
        return workingSpringCounter > 0 && workingGroups.Count > 0 && workingSpringCounter == workingGroups[0];
    }

    private static bool IsRecordNotPossibleAnymore(List<int> workingGroups, int workingSpringCounter)
    {
        return (workingSpringCounter > 0 && workingGroups.Count > 0 && workingSpringCounter != workingGroups[0]) || (workingSpringCounter > 0 && workingGroups.Count == 0);
    }

    private static bool IsRecordPossible(List<int> workingGroups, int workingSpringCounter)
    {
        return (workingGroups.Count == 0 && workingSpringCounter == 0) || (workingGroups.Count == 1 && workingGroups[0] == workingSpringCounter);
    }
}
