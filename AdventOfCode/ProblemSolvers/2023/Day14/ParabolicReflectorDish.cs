using System.Drawing;
using AdventOfCode.InputReader;
using AdventOfCode.ProblemSolvers._2023.Day10;

namespace AdventOfCode.ProblemSolvers._2023.Day14;

public sealed class ParabolicReflectorDish(IReadInputs inputReader) : ProblemSolver(inputReader)
{
    private const string INPUT_FILE_NAME = "InputDay14.txt";

    public override long SolvePart1()
    {
        return SumOfTotalLoads(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public override long SolvePart2()
    {
        return SumOfTotalLoadsAfterCycles(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public static int SumOfTotalLoadsAfterCycles(string[] platform)
    {
        var counter = 0;
        while(counter++ < 1000000000)
        {
            TiltNorth(platform);
            TiltWest(platform);
            TiltSouth(platform);
            TiltEast(platform);
        }
        var result = 0;
        for (int j = 0; j < platform.Length; j++)
        {
            result += platform[j].Count(c => c == 'O') * (platform.Length - j);
        }
        return result;
    }

    public static int SumOfTotalLoads(string[] platform)
    {
        TiltFullNorth(platform);

        var result = 0;
        for (int j = 0; j < platform.Length; j++)
        {
            result += platform[j].Count(c => c == 'O') * (platform.Length - j);
        }
        return result;
    }

    private static void TiltNorth(string[] platform)
    {
        for (int j = 0; j < platform.Length; j++)
        {
            for (int i = 0; i < platform[j].Length; i++)
            {
                if (platform[j][i] == 'O' && j - 1 >= 0 && platform[j - 1][i] == '.')
                {
                    platform[j] = platform[j].Remove(i, 1).Insert(i, ".");
                    platform[j - 1] = platform[j - 1].Remove(i, 1).Insert(i, "O");
                }
            }
        }
    }

    private static void TiltWest(string[] platform)
    {
        for (int j = 0; j < platform.Length; j++)
        {
            for (int i = 0; i < platform[j].Length; i++)
            {
                if (platform[j][i] == 'O' && i - 1 >= 0 && platform[j][i-1] == '.')
                {
                    platform[j] = platform[j].Remove(i, 1).Insert(i, ".");
                    platform[j] = platform[j].Remove(i-1, 1).Insert(i-1, "O");
                }
            }
        }
    }

    private static void TiltSouth(string[] platform)
    {
        for (int j = 0; j < platform.Length; j++)
        {
            for (int i = 0; i < platform[j].Length; i++)
            {
                if (platform[j][i] == 'O' && j + 1 < platform.Length && platform[j + 1][i] == '.')
                {
                    platform[j] = platform[j].Remove(i, 1).Insert(i, ".");
                    platform[j + 1] = platform[j + 1].Remove(i, 1).Insert(i, "O");
                }
            }
        }
    }

    private static void TiltEast(string[] platform)
    {
        for (int j = 0; j < platform.Length; j++)
        {
            for (int i = 0; i < platform[j].Length; i++)
            {
                if (platform[j][i] == 'O' && i + 1 < platform.Length && platform[j][i + 1] == '.')
                {
                    platform[j] = platform[j].Remove(i, 1).Insert(i, ".");
                    platform[j] = platform[j].Remove(i + 1, 1).Insert(i + 1, "O");
                }
            }
        }
    }

    private static void TiltFullNorth(string[] platform)
    {
        for (int j = 0; j < platform.Length; j++)
        {
            for (int i = 0; i < platform[j].Length; i++)
            {
                if (platform[j][i] == 'O')
                {
                    var positionToRoll = new Point(i, j);
                    var shouldBeMoved = false;
                    while (positionToRoll.Y - 1 >= 0 && platform[positionToRoll.Y - 1][positionToRoll.X] == '.')
                    {
                        shouldBeMoved = true;
                        positionToRoll.Offset(PointDirections.North);
                    }
                    if (shouldBeMoved)
                    {
                        platform[j] = platform[j].Remove(i, 1).Insert(i, ".");
                        platform[positionToRoll.Y] = platform[positionToRoll.Y].Remove(i, 1).Insert(i, "O");
                    }
                }
            }
        }
    }
}
