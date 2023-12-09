using AdventOfCode.InputReader;
using AdventOfCode.ProblemSolvers;

namespace AdventOfCode._2023.Day6;

public sealed class WaitForIt(IReadInputs inputReader) : ProblemSolver(inputReader)
{
    private const string INPUT_FILE_NAME = "InputDay6.txt";

    public override long SolvePart1()
    {
        return GetProductOfWinningWays(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public override long SolvePart2()
    {
        return GetWinningWaysAfterParse(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public static long GetProductOfWinningWays(string[] boatRaces)
    {
        var timesList = boatRaces[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
        var distanceList = boatRaces[1].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
        var result = 1L;
        for (int i = 0; i < timesList.Count; i++)
        {
            result *= NumberOfWinningWays(timesList[i], distanceList[i]);
        }
        return result;
    }

    public static long GetWinningWaysAfterParse(string[] boatRaces)
    {
        var time = long.Parse(boatRaces[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Aggregate((a, b) => a + b));
        var distance = long.Parse(boatRaces[1].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Aggregate((a, b) => a + b));
        return NumberOfWinningWays(time, distance);
    }

    public static long NumberOfWinningWays(long time, long recordDistance)
    {
        var numberOfWinningWays = 0L;
        for (long i = 1; i < time; i++)
        {
            if ((time - i) * i > recordDistance)
            {
                numberOfWinningWays++;
            }
        }
        return numberOfWinningWays;
    }

}
