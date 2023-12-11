using AdventOfCode.InputReader;

namespace AdventOfCode.ProblemSolvers._2023.Day9;

public class MirageMaintenance(IReadInputs inputReader) : ProblemSolver(inputReader)
{
    private const string INPUT_FILE_NAME = "InputDay9.txt";

    public override long SolvePart1()
    {
        return SumOfExtrapolatedValues(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public override long SolvePart2()
    {
        return SumOfReversedExtrapolatedValues(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    private static long SumOfExtrapolatedValues(string[] instabilitySensor)
    {
        return instabilitySensor.Sum(GetExtrapolatedValue);
    }

    private static long SumOfReversedExtrapolatedValues(string[] instabilitySensor)
    {
        return instabilitySensor.Sum(GetExtrapolatedValuePart2);
    }

    public static long GetExtrapolatedValue(string history)
    {
        var values = history.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();

        var extrapolations = new List<List<long>>()
        {
            values
        };

        BuildExtrapolationsWithDifferences(extrapolations);

        extrapolations.Last().Add(0);
        for (int i = extrapolations.Count - 2; i >= 0; i--)
        {
            extrapolations[i].Add(extrapolations[i].Last() + extrapolations[i + 1].Last());
        }

        return extrapolations.First().Last();
    }

    private static void BuildExtrapolationsWithDifferences(List<List<long>> extrapolations)
    {
        while (!extrapolations.Last().All(x => x == 0))
        {
            var nextExtrapolation = new List<long>();
            for (int i = 0; i < extrapolations.Last().Count - 1; i++)
            {
                nextExtrapolation.Add(extrapolations.Last()[i + 1] - extrapolations.Last()[i]);
            }
            extrapolations.Add(nextExtrapolation);
        }
    }

    public static long GetExtrapolatedValuePart2(string history)
    {
        var values = history.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
        values.Reverse();

        var extrapolations = new List<List<long>>()
        {
            values
        };

        BuildExtrapolationsWithDifferences(extrapolations);

        extrapolations.Last().Add(0);
        for (int i = extrapolations.Count - 2; i >= 0; i--)
        {
            extrapolations[i].Add(extrapolations[i].Last() + extrapolations[i + 1].Last());
        }

        return extrapolations.First().Last();
    }
}
