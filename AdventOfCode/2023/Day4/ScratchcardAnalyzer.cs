using System.Numerics;

namespace AdventOfCode._2023.Day4;

public static class ScratchcardAnalyzer
{
    private static readonly Dictionary<string, int> _cardCopies = [];

    public static int SolveScratchcardsPart1(string filePath)
    {
        return File.ReadAllLines(Path.GetFullPath(filePath)).Select(GetScratchcardInformations).Sum(GetPoints);
    }

    public static int SolveScratchcardsPart2(string filePath)
    {
        foreach(var card in File.ReadAllLines(Path.GetFullPath(filePath)))
        {
            _cardCopies.Add(card, 1);
        }
        foreach (var card in _cardCopies.Keys)
        {
            SolveScratchcardPart2(card, _cardCopies[card]);
        }
        return _cardCopies.Values.Aggregate((a, b) => a + b);
    }

    public static void SolveScratchcardPart2(string card, int copies)
    {
        var numberOfWinningNumbers = GetNumberOfWinningNumbers(GetScratchcardInformations(card));
        if(numberOfWinningNumbers > 0)
        {
            var gameNumber = GetGameNumber(card);
            foreach (var key in _cardCopies.Keys.Where(card => GetGameNumber(card) <= gameNumber + numberOfWinningNumbers && GetGameNumber(card) > gameNumber))
            {
                _cardCopies[key] += copies;
            }
        }
    }

    private static string GetScratchcardInformations(string card)
    {
        return card.Split(':')[1];
    }

    private static int GetGameNumber(string card)
    {
        return int.Parse(card.Split(':')[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
    }

    private static string[] GetWinningNumberInformations(string cardValue)
    {
        return cardValue.Split('|')[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }

    private static string[] GetScratchedNumbers(string cardValue)
    {
        return cardValue.Split('|')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }

    public static int GetPoints(string cardValue)
    {
        return (int)Math.Pow(2, GetNumberOfWinningNumbers(cardValue) - 1);
    }

    private static int GetNumberOfWinningNumbers(string cardValue)
    {
        return GetWinningNumberInformations(cardValue).Intersect(GetScratchedNumbers(cardValue)).Count();
    }
}
