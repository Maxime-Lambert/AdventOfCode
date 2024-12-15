using System.Drawing;
using AdventOfCode.InputReader;
using AdventOfCode.ProblemSolvers._2023;

namespace AdventOfCode.ProblemSolvers._2024.Day6;

public sealed class GuardGallivant(IReadInputs inputReader) : ProblemSolver(inputReader)
{
    private const string INPUT_FILE_NAME = "2024/InputDay6.txt";

    public override long SolvePart1()
    {
        return NumberOfDifferentCasesPatrolled(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public override long SolvePart2()
    {
        return NumberOfDifferentCasesPatrolled(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public static Point PointDirectionFromChar(char guard_char) => guard_char switch
    {
        '^' => PointDirections.North,
        '>' => PointDirections.East,
        '<' => PointDirections.West,
        'v' => PointDirections.South,
        _ => new Point(0, 0)
    };
    
    public static long NumberOfDifferentCasesPatrolled(string[] input)
    {
        var guardPosition = new Point(0, 0);
        var guardOrientation = new Point(0, 0);
        for (int i = 0; i < input.Length; i++)
        {
            for(int j = 0; j < input[i].Length; j++)
            {
                if (input[i][j] == '^' || input[i][j] == '>' || input[i][j] == '<' || input[i][j] == 'v')
                {
                    guardPosition = new Point(j, i);
                    guardOrientation = PointDirectionFromChar(input[i][j]);
                }
            }
        }

        HashSet<Point> theoLeMeilleur = [guardPosition];
        while(guardPosition.X + guardOrientation.X >= 0 && 
                guardPosition.X + guardOrientation.X < input[0].Length && 
                guardPosition.Y + guardOrientation.Y >= 0 && 
                guardPosition.Y + guardOrientation.Y < input.Length
            )
        {
            switch(input[guardPosition.Y + guardOrientation.Y][guardPosition.X + guardOrientation.X])
            {
                case '#':
                    if (guardOrientation == PointDirections.West)
                    {
                        guardOrientation = PointDirections.North;
                    }
                    else if (guardOrientation == PointDirections.East)
                    {
                        guardOrientation = PointDirections.South;
                    }
                    else if (guardOrientation == PointDirections.North)
                    {
                        guardOrientation = PointDirections.East;
                    }
                    else if (guardOrientation == PointDirections.South)
                    {
                        guardOrientation = PointDirections.West;
                    }
                    break;
                default: guardPosition.Offset(guardOrientation); theoLeMeilleur.Add(guardPosition); break;
            }
        }
        return theoLeMeilleur.Count;

    }

}
