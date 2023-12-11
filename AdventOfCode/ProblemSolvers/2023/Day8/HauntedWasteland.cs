using AdventOfCode.InputReader;

namespace AdventOfCode.ProblemSolvers._2023.Day8;

public class HauntedWasteland(IReadInputs inputReader) : ProblemSolver(inputReader)
{
    private const string INPUT_FILE_NAME = "InputDay8.txt";
    private const string PART1_STARTING_POSITION = "AAA";
    private const string PART1_ENDING_POSITION = "ZZZ";

    public override long SolvePart1()
    {
        return CalculateStepsToReachZZZ(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public override long SolvePart2()
    {
        return CalculateStepsToReachZSimultaneously(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public static int CalculateStepsToReachZZZ(string[] network)
    {
        var nodesMap = ExtractNodesMap(network);
        var pathToFollow = network[0];
        var steps = 0;
        var currentPosition = PART1_STARTING_POSITION;

        while (!string.Equals(currentPosition, PART1_ENDING_POSITION))
        {
            if (pathToFollow[steps % network[0].Length] == 'R')
            {
                currentPosition = nodesMap[currentPosition].RightDirection;
            }
            else
            {
                currentPosition = nodesMap[currentPosition].LeftDirection;
            }
            steps++;
        }
        return steps;
    }

    public static long CalculateStepsToReachZSimultaneously(string[] network)
    {
        var nodesMap = ExtractNodesMap(network);
        var pathToFollow = network[0];
        var steps = 0;

        var currentPositions = nodesMap.Keys.Where(node => node.EndsWith('A')).ToList();
        var loopSteps = new Dictionary<string, long>();

        while (loopSteps.Count != currentPositions.Count())
        {
            if (pathToFollow[steps % network[0].Length] == 'R')
            {
                currentPositions = currentPositions.Select(position => nodesMap[position].RightDirection).ToList();
            }
            else
            {
                currentPositions = currentPositions.Select(position => nodesMap[position].LeftDirection).ToList();
            }
            steps++;
            foreach (var currentPosition in currentPositions)
            {
                if (currentPosition.EndsWith('Z') && !loopSteps.ContainsKey(currentPosition))
                {
                    loopSteps.Add(currentPosition, steps);
                }
            }
        }
        return loopSteps.Values.Aggregate((a, b) => GetLowestCommonMultiple(a, b));
    }

    private static long GetGreatestCommonFactor(long a, long b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    private static long GetLowestCommonMultiple(long a, long b)
    {
        return (a / GetGreatestCommonFactor(a, b)) * b;
    }

    private static Dictionary<string, Directions> ExtractNodesMap(string[] network)
    {
        var nodesMap = new Dictionary<string, Directions>();
        for (int i = 2; i < network.Length; i++)
        {
            var currentLine = network[i].Split('=', StringSplitOptions.TrimEntries);
            var directionsInformations = currentLine[1].Split(",", StringSplitOptions.TrimEntries);
            var leftDirection = directionsInformations[0][1..];
            var rightDirection = directionsInformations[1][..3];
            nodesMap.Add(currentLine[0], new Directions(leftDirection, rightDirection));
        }
        return nodesMap;
    }
}
