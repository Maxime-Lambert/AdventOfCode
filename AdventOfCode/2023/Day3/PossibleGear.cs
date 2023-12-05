using System.Drawing;

namespace AdventOfCode._2023.Day3;
internal class PossibleGear
{
    public List<Point> PossibleNumberPositions { get; set; }

    public PossibleGear(Point startingPosition, Point boundPoint)
    {
        PossibleNumberPositions = [];
        for (int x = startingPosition.X - 1; x <= startingPosition.X + 1; x++)
        {
            PossibleNumberPositions.Add(new Point(x, startingPosition.Y - 1));
            PossibleNumberPositions.Add(new Point(x, startingPosition.Y + 1));
        }
        PossibleNumberPositions.Add(new Point(startingPosition.X - 1, startingPosition.Y));
        PossibleNumberPositions.Add(new Point(startingPosition.X + 1, startingPosition.Y));
        PossibleNumberPositions.RemoveAll(position => position.X < 0 || position.X > boundPoint.X || position.Y < 0 || position.Y > boundPoint.Y);
    }
}
