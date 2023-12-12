using System.Drawing;

namespace AdventOfCode.ProblemSolvers._2023.Day10;

internal static class PointDirections
{
    public static readonly Point North = new(0, -1);
    public static readonly Point South = new(0, 1);
    public static readonly Point East = new(1, 0);
    public static readonly Point West = new(-1, 0);

    public static readonly List<Point> Directions = [North, South, East, West];

    public static bool IsNorth(Point point)
    {
        return Enum.Equals(point, North);
    }

    public static bool IsSouth(Point point)
    {
        return Enum.Equals(point, South);
    }

    public static bool IsEast(Point point)
    {
        return Enum.Equals(point, East);
    }

    public static bool IsWest(Point point)
    {
        return Enum.Equals(point, West);
    }

    public static bool IsHorizontal(Point point)
    {
        return point.Y == 0 && point.X != 0;
    }

    public static bool IsVertical(Point point)
    {
        return point.X == 0 && point.Y != 0;
    }
}
