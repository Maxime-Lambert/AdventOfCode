using System.Drawing;

namespace AdventOfCode._2023.Day3;

internal class PossiblePartNumber
{
    public int Number { get; set; }

    public List<Point> PossibleSymbolValues { get; set; }

    public PossiblePartNumber(string number, Point startingPosition)
    {
        Number = int.Parse(number);
        PossibleSymbolValues = [];
        for (int x = startingPosition.X - 1; x <= startingPosition.X + number.Length; x++)
        {
            PossibleSymbolValues.Add(new Point(x, startingPosition.Y - 1));
            PossibleSymbolValues.Add(new Point(x, startingPosition.Y + 1));
        }
        PossibleSymbolValues.Add(new Point(startingPosition.X - 1, startingPosition.Y));
        PossibleSymbolValues.Add(new Point(startingPosition.X + number.Length, startingPosition.Y));
    }
}
