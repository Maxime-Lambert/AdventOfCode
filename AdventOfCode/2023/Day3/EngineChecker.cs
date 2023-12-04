using System.Drawing;
using System.Text;

namespace AdventOfCode._2023.Day3;

public static class EngineChecker
{
    public static int SolveEngineGamePart1(string filePath)
    {
        return SumEngineValidParts(File.ReadAllLines(Path.GetFullPath(filePath)));
    }

    public static int SumEngineValidParts(string[] engineSchematic)
    {
        var possiblePartNumbersList = new List<PossiblePartNumber>();
        var symbolsPositionList = new List<Point>();
        StringBuilder stringBuilder = new StringBuilder();

        for (int y = 0; y < engineSchematic.Length; y++)
        {
            for (int x = 0; x < engineSchematic[y].Length; x++)
            {
                var actualChar = engineSchematic[y][x];
                if (Char.IsDigit(actualChar))
                {
                    stringBuilder.Append(actualChar);
                }
                else
                {
                    if (stringBuilder.Length > 0)
                    {
                        possiblePartNumbersList.Add(new PossiblePartNumber(stringBuilder.ToString(), new Point(x - stringBuilder.Length, y)));
                        stringBuilder.Clear();
                    }
                    if (actualChar != '.')
                    {
                        symbolsPositionList.Add(new Point(x, y));
                    }
                }
            }
            if (stringBuilder.Length > 0)
            {
                possiblePartNumbersList.Add(new PossiblePartNumber(stringBuilder.ToString(), new Point(engineSchematic[y].Length - stringBuilder.Length, y)));
                stringBuilder.Clear();
            }
        }
        return possiblePartNumbersList.Where(partNumber => symbolsPositionList.Exists(symbol => partNumber.PossibleSymbolValues.Contains(symbol)))
            .Sum(partNumber => partNumber.Number);
    }
}
