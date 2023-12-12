using System.Drawing;
using AdventOfCode.InputReader;

namespace AdventOfCode.ProblemSolvers._2023.Day10;

public sealed class PipeMaze(IReadInputs inputReader) : ProblemSolver(inputReader)
{
    private const string INPUT_FILE_NAME = "InputDay10.txt";

    public override long SolvePart1()
    {
        return FurthestDistanceInLoopFromS(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public override long SolvePart2()
    {
        return 0;
    }

    public static int FurthestDistanceInLoopFromS(string[] pipeMaze)
    {
        var startingPoint = FindStartingPoint(pipeMaze);

        foreach (var direction in PointDirections.Directions)
        {
            var loopSize = GetLoopSize(pipeMaze, startingPoint, direction);
            if (loopSize > 0)
            {
                return loopSize / 2 + loopSize % 2;
            }
        }
        return 0;
    }

    private static int GetLoopSize(string[] pipeMaze, Point startingPoint, Point startingDirection)
    {
        var counter = 0;
        var actualCoordinates = new Point(startingPoint.X, startingPoint.Y);
        var lastDirection = startingDirection;
        actualCoordinates.Offset(lastDirection);

        while (AreCoordinatesStillInMaze(pipeMaze, actualCoordinates))
        {
            switch (pipeMaze[actualCoordinates.Y][actualCoordinates.X])
            {
                case '|':
                    if (PointDirections.IsHorizontal(lastDirection)) return 0;
                    if (PointDirections.IsSouth(lastDirection))
                    {
                        actualCoordinates.Offset(PointDirections.South); break;
                    }
                    else
                    {
                        actualCoordinates.Offset(PointDirections.North); break;
                    }
                case '-':
                    if (PointDirections.IsVertical(lastDirection)) return 0;
                    if (PointDirections.IsWest(lastDirection))
                    {
                        actualCoordinates.Offset(PointDirections.West); break;
                    }
                    else
                    {
                        actualCoordinates.Offset(PointDirections.East); break;
                    }
                case 'L':
                    if (PointDirections.IsEast(lastDirection) || PointDirections.IsNorth(lastDirection)) return 0;
                    if (PointDirections.IsWest(lastDirection))
                    {
                        actualCoordinates.Offset(PointDirections.North); lastDirection = PointDirections.North; break;
                    }
                    else
                    {
                        actualCoordinates.Offset(PointDirections.East); lastDirection = PointDirections.East; break;
                    }
                case 'J':
                    if (PointDirections.IsWest(lastDirection) || PointDirections.IsNorth(lastDirection)) return 0;
                    if (PointDirections.IsEast(lastDirection))
                    {
                        actualCoordinates.Offset(PointDirections.North); lastDirection = PointDirections.North; break;
                    }
                    else
                    {
                        actualCoordinates.Offset(PointDirections.West); lastDirection = PointDirections.West; break;
                    }
                case '7':
                    if (PointDirections.IsWest(lastDirection) || PointDirections.IsSouth(lastDirection)) return 0;
                    if (PointDirections.IsEast(lastDirection))
                    {
                        actualCoordinates.Offset(PointDirections.South); lastDirection = PointDirections.South; break;
                    }
                    else
                    {
                        actualCoordinates.Offset(PointDirections.West); lastDirection = PointDirections.West; break;
                    }
                case 'F':
                    if (PointDirections.IsEast(lastDirection) || PointDirections.IsSouth(lastDirection)) return 0;
                    if (PointDirections.IsWest(lastDirection))
                    {
                        actualCoordinates.Offset(PointDirections.South); lastDirection = PointDirections.South; break;
                    }
                    else
                    {
                        actualCoordinates.Offset(PointDirections.East); lastDirection = PointDirections.East; break;
                    }
                case '.': return 0;
                case 'S': return counter;
            }
            counter++;
        }
        return 0;
    }

    private static bool AreCoordinatesStillInMaze(string[] pipeMaze, Point actualCoordinates)
    {
        return actualCoordinates.X >= 0 && actualCoordinates.X < pipeMaze[0].Length
                    && actualCoordinates.Y >= 0 && actualCoordinates.Y < pipeMaze.Length;
    }

    private static Point FindStartingPoint(string[] pipeMaze)
    {
        for (int j = 0; j < pipeMaze.Length; j++)
        {
            for (int i = 0; i < pipeMaze[j].Length; i++)
            {
                if (pipeMaze[j][i] == 'S')
                {
                    return new Point(i, j);
                }
            }
        }
        return new Point(0, 0);
    }
}
