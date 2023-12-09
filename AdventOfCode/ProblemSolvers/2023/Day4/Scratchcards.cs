using AdventOfCode.InputReader;
using AdventOfCode.ProblemSolvers;

namespace AdventOfCode._2023.Day4;

public sealed class Scratchcards(IReadInputs inputReader) : ProblemSolver(inputReader)
{
    private const string INPUT_FILE_NAME = "InputDay4.txt";

    private static Dictionary<string, int> _cardCopies;

    public override long SolvePart1()
    {
        return _inputReader.GetProblemInput(INPUT_FILE_NAME).Select(GetScratchcardInformations).Sum(GetPoints);
    }

    public override long SolvePart2()
    {
        return GetNumberOfCopies(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public static long GetNumberOfCopies(string[] scratchCards)
    {
        _cardCopies = [];
        foreach (var scratchCard in scratchCards)
        {
            _cardCopies.Add(scratchCard, 1);
        }
        foreach (var scratchCard in _cardCopies.Keys)
        {
            PropagateCopies(scratchCard, _cardCopies[scratchCard]);
        }
        return _cardCopies.Values.Aggregate((a, b) => a + b);
    }

    private static void PropagateCopies(string scratchCard, int numberOfCopies)
    {
        var winningNumbers = GetNumberOfWinningNumbers(GetScratchcardInformations(scratchCard));
        if (winningNumbers > 0)
        {
            var gameNumber = GetGameNumber(scratchCard);
            foreach (var key in _cardCopies.Keys.Where(card => GetGameNumber(card) <= gameNumber + winningNumbers &&
                                                                GetGameNumber(card) > gameNumber))
            {
                _cardCopies[key] += numberOfCopies;
            }
        }
    }

    private static string GetScratchcardInformations(string scratchCard)
    {
        return scratchCard.Split(':')[1];
    }

    private static int GetGameNumber(string scratchCard)
    {
        return int.Parse(scratchCard.Split(':')[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
    }

    private static string[] GetWinningNumberInformations(string scratchCardInformations)
    {
        return scratchCardInformations.Split('|')[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }

    private static string[] GetScratchedNumbers(string scratchCardInformations)
    {
        return scratchCardInformations.Split('|')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }

    public static int GetPoints(string scratchCardInformations)
    {
        return (int)Math.Pow(2, GetNumberOfWinningNumbers(scratchCardInformations) - 1);
    }

    private static int GetNumberOfWinningNumbers(string scratchCardInformations)
    {
        return GetWinningNumberInformations(scratchCardInformations).Intersect(GetScratchedNumbers(scratchCardInformations)).Count();
    }
}
