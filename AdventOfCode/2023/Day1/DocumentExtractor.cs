using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day1;

public static class DocumentExtractor
{
    public static readonly string patternPart1 = @"\d";
    public static readonly string patternPart2 = @"\d|one|two|three|four|five|six|seven|eight|nine";

    public static int GetCalibrationValue(string calibrationLine, string pattern)
    {
        var firstDigit = StringDigitToInt(Regex.Match(calibrationLine, pattern).Value);
        var lastDigit = StringDigitToInt(Regex.Match(calibrationLine, pattern, RegexOptions.RightToLeft).Value);

        return (firstDigit * 10) + lastDigit;
    }

    public static int GetSumOfCalibrationValues(string filePath, Part part)
    {
        return part switch
        {
            Part.One => File.ReadAllLines(Path.GetFullPath(filePath)).Sum(calibrationLine => GetCalibrationValue(calibrationLine, patternPart1)),
            Part.Two => File.ReadAllLines(Path.GetFullPath(filePath)).Sum(calibrationLine => GetCalibrationValue(calibrationLine, patternPart2))
        };
    }

    private static int StringDigitToInt(string s)
    {
        return s switch
        {
            "1" => 1,
            "2" => 2,
            "3" => 3,
            "4" => 4,
            "5" => 5,
            "6" => 6,
            "7" => 7,
            "8" => 8,
            "9" => 9,
            "one" => 1,
            "two" => 2,
            "three" => 3,
            "four" => 4,
            "five" => 5,
            "six" => 6,
            "seven" => 7,
            "eight" => 8,
            "nine" => 9,
            _ => 0
        };
    }
}
