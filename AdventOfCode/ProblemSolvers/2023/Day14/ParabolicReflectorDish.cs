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
        return 0;
    }

    public static int SumOfTotalLoads(string[] platform)
    {
        TiltNorth(platform);

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
