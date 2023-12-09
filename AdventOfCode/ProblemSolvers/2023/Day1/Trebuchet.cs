using System.Text.RegularExpressions;
using AdventOfCode.InputReader;
using AdventOfCode.ProblemSolvers;

namespace AdventOfCode._2023.Day1;

public sealed class Trebuchet(IReadInputs inputReader) : ProblemSolver(inputReader)
{
    private const string INPUT_FILE_NAME = "InputDay1.txt";

    private const string PATTERN_DIGIT = @"\d";
    private const string PATTERN_DIGIT_OR_DIGIT_AS_TEST = @"\d|one|two|three|four|five|six|seven|eight|nine";

    public override long SolvePart1()
    {
        return _inputReader.GetProblemInput(INPUT_FILE_NAME).Sum(calibrationLine => GetCalibrationValue(calibrationLine, PATTERN_DIGIT));
    }

    public override long SolvePart2()
    {
        return _inputReader.GetProblemInput(INPUT_FILE_NAME).Sum(calibrationLine => GetCalibrationValue(calibrationLine, PATTERN_DIGIT_OR_DIGIT_AS_TEST));
    }

    public static int GetCalibrationValue(string calibrationLine, string pattern)
    {
        var firstDigit = StringDigitToInt(Regex.Match(calibrationLine, pattern).Value);
        var lastDigit = StringDigitToInt(Regex.Match(calibrationLine, pattern, RegexOptions.RightToLeft).Value);
        return (firstDigit * 10) + lastDigit;
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
