using System.Drawing;

namespace AdventOfCode._2023.Day3;

internal class EngineNumber
{
    public int Number { get; set; }

    public List<Point> DigitsPosition { get; set; }

    public EngineNumber(string number, Point startingPosition)
    {
        Number = int.Parse(number);
        DigitsPosition = [];
        for (int x = startingPosition.X; x < startingPosition.X + number.Length; x++)
        {
            DigitsPosition.Add(new Point(x, startingPosition.Y));
        }
    }
}
