using AdventOfCode.InputReader;

namespace AdventOfCode.ProblemSolvers._2023.Day13;

public sealed class PointOfIncidence(IReadInputs inputReader) : ProblemSolver(inputReader)
{
    private const string INPUT_FILE_NAME = "InputDay13.txt";

    public override long SolvePart1()
    {
        return ParsePatterns(_inputReader.GetProblemInput(INPUT_FILE_NAME)).Sum(FindReflectionAndAddColumns);
    }

    public override long SolvePart2()
    {
        return 0;
    }

    private static List<string[]> ParsePatterns(string[] patterns)
    {
        var patternsList = new List<string[]>();
        List<string> currentPattern = [];
        var counter = 0;
        foreach (string line in patterns)
        {
            if (string.IsNullOrEmpty(line))
            {
                patternsList.Add([.. currentPattern]);
                currentPattern = [];
                counter++;
            }
            else
            {
                currentPattern.Add(line);
            }
        }
        patternsList.Add([.. currentPattern]);
        return patternsList;
    }

    public static int FindReflectionAndAddColumns(string[] pattern)
    {
        for (int j = 0; j < pattern.Length - 1; j++)
        {
            if (string.Equals(pattern[j], pattern[j + 1]))
            {
                var isReflection = true;
                for (int b = j - 1; b >= 0 && j + 1 + (j - b) < pattern.Length; b--)
                {
                    isReflection &= string.Equals(pattern[b], pattern[j + 1 + (j - b)]);
                }
                if (isReflection)
                {
                    return (j + 1) * 100;
                }
            }
        }
        for (int j = 0; j < pattern.Length; j++)
        {
            for (int i = 0; i < pattern[j].Length - 1; i++)
            {
                if (pattern[j][i] == pattern[j][i + 1])
                {
                    var isReflection = true;
                    for (int b = 0; b < pattern.Length; b++)
                    {
                        for (int c = i; c >= 0 && i + 1 + (i - c) < pattern[b].Length; c--)
                        {
                            isReflection &= pattern[b][c] == pattern[b][i + 1 + (i - c)];
                        }
                    }
                    if (isReflection)
                    {
                        return i + 1;
                    }
                }
            }
        }
        return 0;
    }
}
