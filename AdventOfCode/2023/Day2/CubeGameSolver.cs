namespace AdventOfCode._2023.Day2;

public static class CubeGameSolver
{
    private static readonly int MAX_RED_VALUE = 12;
    private static readonly int MAX_GREEN_VALUE = 13;
    private static readonly int MAX_BLUE_VALUE = 14;

    private static readonly string RED_TEXT = "red";
    private static readonly string BLUE_TEXT = "blue";
    private static readonly string GREEN_TEXT = "green";

    public static int SolveCubeGame(string filePath)
    {
        return File.ReadAllLines(Path.GetFullPath(filePath))
            .Where(gameInformations => SolveGame(GetGameValues(gameInformations)))
            .Sum(GetGameId);
    }

    private static string GetGameValues(string gameInformations)
    {
        return gameInformations.Split(':')[1];
    }

    private static int GetGameId(string gameInformations)
    {
        return int.Parse(gameInformations.Split(':')[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
    }

    public static bool SolveGame(string gameValues)
    {
        return Array.TrueForAll(gameValues.Split(';'), SolveDraw);
    }

    private static bool SolveDraw(string drawValues)
    {
        return Array.TrueForAll(drawValues.Split(','), SolveColorCubeValue);
    }

    private static bool SolveColorCubeValue(string colorCubeValue)
    {
        var cubeValue = GetNumberOfCubes(colorCubeValue);
        if (colorCubeValue.Contains(BLUE_TEXT))
        {
            return cubeValue.CompareTo(MAX_BLUE_VALUE) <= 0;
        }
        if (colorCubeValue.Contains(RED_TEXT))
        {
            return cubeValue.CompareTo(MAX_RED_VALUE) <= 0;
        }
        if (colorCubeValue.Contains(GREEN_TEXT))
        {
            return cubeValue.CompareTo(MAX_GREEN_VALUE) <= 0;
        }
        return false;
    }

    private static int GetNumberOfCubes(string cubeValue)
    {
        return int.Parse(cubeValue.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]);
    }
}
