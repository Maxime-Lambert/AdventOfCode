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
        return 0;
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
