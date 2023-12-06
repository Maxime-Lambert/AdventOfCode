namespace AdventOfCode._2023.Day6;

public static class BoatRace
{
    public static long SolveBoatRacePart1(string filePath)
    {
        var fileLines = File.ReadAllLines(Path.GetFullPath(filePath)).ToList();
        var timesList = fileLines[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
        var distanceList = fileLines[1].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
        var result = 1L;
        for (int i = 0; i < timesList.Count; i++)
        {
            result *= NumberOfWinningWays(timesList[i], distanceList[i]);
        }
        return result;
    }

    public static long SolveBoatRacePart2(string filePath)
    {
        var fileLines = File.ReadAllLines(Path.GetFullPath(filePath)).ToList();
        var time = long.Parse(fileLines[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Aggregate((a, b) => a + b));
        var distance = long.Parse(fileLines[1].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Aggregate((a, b) => a + b));
        return NumberOfWinningWays(time, distance);
    }

    public static long NumberOfWinningWays(long time, long recordDistance)
    {
        var numberOfWinningWays = 0L;
        for (long i = 1; i < time; i++)
        {
            if ((time - i) * i > recordDistance)
            {
                numberOfWinningWays++;
            }
        }
        return numberOfWinningWays;
    }
}
