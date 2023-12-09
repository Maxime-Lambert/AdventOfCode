using System.Drawing;
using System.Text;
using AdventOfCode.InputReader;
using AdventOfCode.ProblemSolvers;

namespace AdventOfCode._2023.Day3;

public sealed class GearRatios(IReadInputs inputReader) : ProblemSolver(inputReader)
{
    private const string INPUT_FILE_NAME = "InputDay3.txt";

    public override long SolvePart1()
    {
        return SumValidEngineParts(inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public override long SolvePart2()
    {
        return SumGearRatios(inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public static int SumGearRatios(string[] engineSchematic)
    {
        var engineNumberList = new List<EngineNumber>();
        var possibleGearList = new List<PossibleGear>();
        StringBuilder stringBuilder = new StringBuilder();

        ExtractGearsAndNumbersCoordinates(engineSchematic, engineNumberList, possibleGearList, stringBuilder);

        var validGearList = possibleGearList.Where(gear => engineNumberList.Where(number => number.DigitsPosition.Intersect(gear.PossibleNumberPositions).Any()).Count() == 2).ToList();
        return validGearList.Sum(gear => engineNumberList.Where(number => number.DigitsPosition.Intersect(gear.PossibleNumberPositions).Any()).Select(nb => nb.Number).Aggregate((a, b) => a * b));
    }

    private static void ExtractGearsAndNumbersCoordinates(string[] engineSchematic, List<EngineNumber> engineNumberList, List<PossibleGear> possibleGearList, StringBuilder stringBuilder)
    {
        var boundPoint = new Point(engineSchematic[0].Length - 1, engineSchematic.Length - 1);
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
                        engineNumberList.Add(new EngineNumber(stringBuilder.ToString(), new Point(x - stringBuilder.Length, y)));
                        stringBuilder.Clear();
                    }
                    if (actualChar == '*')
                    {
                        possibleGearList.Add(new PossibleGear(new Point(x, y), boundPoint));
                    }
                }
            }
            if (stringBuilder.Length > 0)
            {
                engineNumberList.Add(new EngineNumber(stringBuilder.ToString(), new Point(engineSchematic[y].Length - stringBuilder.Length, y)));
                stringBuilder.Clear();
            }
        }
    }

    public static int SumValidEngineParts(string[] engineSchematic)
    {
        var possiblePartNumbersList = new List<PossiblePartNumber>();
        var symbolsPositionList = new List<Point>();
        StringBuilder stringBuilder = new StringBuilder();

        ExtractPartNumbersAndSymbolsCoordinates(engineSchematic, possiblePartNumbersList, symbolsPositionList, stringBuilder);

        return possiblePartNumbersList.Where(partNumber => symbolsPositionList.Exists(symbol => partNumber.PossibleSymbolValues.Contains(symbol)))
            .Sum(partNumber => partNumber.Number);
    }

    private static void ExtractPartNumbersAndSymbolsCoordinates(string[] engineSchematic, List<PossiblePartNumber> possiblePartNumbersList, List<Point> symbolsPositionList, StringBuilder stringBuilder)
    {
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
    }
}
