using AdventOfCode.InputReader;

namespace AdventOfCode.ProblemSolvers._2024.Day1;
public sealed class HistorianHysteria(IReadInputs inputReader) : ProblemSolver(inputReader)
{
    private const string INPUT_FILE_NAME = "2024/InputDay1.txt";

    public override long SolvePart1()
    {
        return SumOfTotalDistance(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public override long SolvePart2()
    {
        return SumOfSimilarityScore(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public static long SumOfTotalDistance(string[] input) {
        IEnumerable<string> leftValues = [];
        IEnumerable<string> rightValues = [];

        foreach (var line in input) {
            var splittedLine = line.Split(' ');
            leftValues = leftValues.Append(splittedLine[0]);
            rightValues = rightValues.Append(splittedLine[^1]);
        }

        leftValues = leftValues.Order();
        rightValues = rightValues.Order();

        var result = 0;
        for(int i = 0; i < leftValues.Count(); i++)
        {
            result += Math.Abs(int.Parse(leftValues.ElementAt(i)) - int.Parse(rightValues.ElementAt(i)));
        }
        return result;
    }

    public static long SumOfSimilarityScore(string[] input)
    {
        IEnumerable<string> leftValues = [];
        Dictionary<string, int> valueToSimilarityScore = new();

        foreach (var line in input)
        {
            var splittedLine = line.Split(' ');
            leftValues = leftValues.Append(splittedLine[0]);
            if(!valueToSimilarityScore.TryAdd(splittedLine[^1],1))
            {
                valueToSimilarityScore[splittedLine[^1]]++;
            }
        }
        var result = 0;
        foreach (var value in leftValues)
        {
            if (valueToSimilarityScore.TryGetValue(value, out int similarityScore))
            {
                result += int.Parse(value) * similarityScore;
            }
        }
        return result;
    }
}
