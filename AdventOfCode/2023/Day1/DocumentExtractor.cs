using System.Buffers;

namespace AdventOfCode._2023.Day1;

public static class DocumentExtractor
{
    private static readonly SearchValues<char> _charDigits = SearchValues.Create(['1', '2', '3', '4', '5', '6', '7', '8', '9']);
    private static readonly string _inputFileName = "2023/Day1/input.txt";

    public static int GetCalibrationValue(string calibrationLine)
    {
        var calibrationLineAsSpan = calibrationLine.AsSpan();

        var firstDigit = calibrationLineAsSpan[calibrationLineAsSpan.IndexOfAny(_charDigits)];
        var lastDigit = calibrationLineAsSpan[calibrationLineAsSpan.LastIndexOfAny(_charDigits)];

        return (int)((char.GetNumericValue(firstDigit) * 10) + char.GetNumericValue(lastDigit));
    }

    public static int GetSumOfCalibrationValues()
    {
        return File.ReadAllLines(Path.GetFullPath(_inputFileName)).Sum(GetCalibrationValue);
    }
}
