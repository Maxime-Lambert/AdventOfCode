using System.Drawing;

namespace AdventOfCode._2023.Day3;

internal class PossiblePartNumber
{
    public int Number { get; init; }

    public List<Point> PossibleSymbolValues { get; init; }

    public PossiblePartNumber(string partNumber, Point startingPosition)
    {
        Number = int.Parse(partNumber);
        PossibleSymbolValues = [];
        for (int x = startingPosition.X - 1; x <= startingPosition.X + partNumber.Length; x++)
        {
            PossibleSymbolValues.Add(new Point(x, startingPosition.Y - 1));
            PossibleSymbolValues.Add(new Point(x, startingPosition.Y + 1));
        }
        PossibleSymbolValues.Add(new Point(startingPosition.X - 1, startingPosition.Y));
        PossibleSymbolValues.Add(new Point(startingPosition.X + partNumber.Length, startingPosition.Y));
    }
}
