using System.Text.RegularExpressions;
using AdventOfCode.InputReader;

namespace AdventOfCode.ProblemSolvers._2024.Day3;

public sealed class MullItOver(IReadInputs inputReader) : ProblemSolver(inputReader)
{
    private const string INPUT_FILE_NAME = "2024/InputDay3.txt";
    private const string REGEX_PART1 = @"mul\(\d+,\d+\)";
    private const string REGEX_PART2 = @"mul\(\d+,\d+\)|do\(\)|don't\(\)";
    private const string REGEX_NUMBER = @"\d+";

    public override long SolvePart1()
    {
        return AddUncorruptedMuls(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public override long SolvePart2()
    {
        return AddUncorruptedMulsWithDoesAndDont(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public static long AddUncorruptedMuls(string[] memory)
    {
        var result = 0;
        foreach(var line in memory)
        {
            var uncorruptedMuls = Regex.Matches(line, REGEX_PART1);
            foreach(Match mul in uncorruptedMuls)
            {
                var numbers = Regex.Matches(mul.Value, REGEX_NUMBER);
                result += int.Parse(numbers[0].Value) * int.Parse(numbers[1].Value);
            }
        }
        return result;
    }

    public static long AddUncorruptedMulsWithDoesAndDont(string[] memory)
    {
        var doMul = true;
        var result = 0;
        foreach (var line in memory)
        {
            var uncorruptedMuls = Regex.Matches(line, REGEX_PART2);
            foreach (Match mul in uncorruptedMuls)
            {
                switch(mul.Value)
                {
                    case "do()": doMul = true; break;
                    case "don't()": doMul = false; break;
                    default: if (doMul)
                        {
                            var numbers = Regex.Matches(mul.Value, REGEX_NUMBER);
                            result += int.Parse(numbers[0].Value) * int.Parse(numbers[1].Value);
                        }
                        break;
                }
            }
        }
        return result;
    }
}
