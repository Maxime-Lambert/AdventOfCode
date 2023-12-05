namespace AdventOfCode._2023.Day4;

public static class ScratchcardAnalyzer
{
    public static int SolveScratchcard(string filePath)
    {
        return File.ReadAllLines(Path.GetFullPath(filePath)).Select(GetScratchcardInformations).Sum(GetPoints);
    }

    private static string GetScratchcardInformations(string line)
    {
        return line.Split(':')[1];
    }

    private static string[] GetWinningNumbers(string cardValue)
    {
        return cardValue.Split('|')[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }

    private static string[] GetScratchedNumbers(string cardValue)
    {
        return cardValue.Split('|')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }

    public static int GetPoints(string cardValue)
    {
        return (int)Math.Pow(2, GetWinningNumbers(cardValue).Intersect(GetScratchedNumbers(cardValue)).Count() - 1);
    }
}
