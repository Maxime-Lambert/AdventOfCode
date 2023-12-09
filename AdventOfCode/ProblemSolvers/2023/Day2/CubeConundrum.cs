using AdventOfCode.InputReader;
using AdventOfCode.ProblemSolvers;

namespace AdventOfCode._2023.Day2;

public sealed class CubeConundrum(IReadInputs inputReader) : ProblemSolver(inputReader)
{
    private const string INPUT_FILE_NAME = "InputDay2.txt";

    private const int MAX_RED_VALUE = 12;
    private const int MAX_GREEN_VALUE = 13;
    private const int MAX_BLUE_VALUE = 14;

    private const string RED_TEXT = "red";
    private const string BLUE_TEXT = "blue";
    private const string GREEN_TEXT = "green";

    public override long SolvePart1()
    {
        return _inputReader.GetProblemInput(INPUT_FILE_NAME)
            .Sum(gameInformations => AreAllGamesPossible(GetGameSets(gameInformations)) ? GetGameId(gameInformations) : 0);
    }

    public override long SolvePart2()
    {
        return _inputReader.GetProblemInput(INPUT_FILE_NAME)
            .Sum(gameInformations => GetProductOfMinimumValueForEachColor(GetGameSets(gameInformations)));
    }

    private static string GetGameSets(string gameInformations)
    {
        return gameInformations.Split(':')[1];
    }

    private static int GetGameId(string gameInformations)
    {
        return int.Parse(gameInformations.Split(':')[0]
                                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
    }

    public static bool AreAllGamesPossible(string gameSets)
    {
        return Array.TrueForAll(gameSets.Split(';'), IsGamePossible);
    }

    private static bool IsGamePossible(string gameSet)
    {
        return Array.TrueForAll(gameSet.Split(','), IsColorValuePossible);
    }

    private static bool IsColorValuePossible(string color)
    {
        var colorValue = GetNumberOfCubes(color);
        if (color.Contains(BLUE_TEXT))
        {
            return colorValue.CompareTo(MAX_BLUE_VALUE) <= 0;
        }
        if (color.Contains(RED_TEXT))
        {
            return colorValue.CompareTo(MAX_RED_VALUE) <= 0;
        }
        if (color.Contains(GREEN_TEXT))
        {
            return colorValue.CompareTo(MAX_GREEN_VALUE) <= 0;
        }
        return false;
    }

    private static int GetNumberOfCubes(string color)
    {
        return int.Parse(color.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]);
    }

    public static int GetProductOfMinimumValueForEachColor(string gameSets)
    {
        CubeGame cubeGame = new CubeGame();
        foreach (var gameSet in gameSets.Split(';'))
        {
            GetMinimumValueForEachColor(cubeGame, gameSet);
        }
        return cubeGame.GetProductOfColorValues();
    }

    private static void GetMinimumValueForEachColor(CubeGame cubeGame, string gameSet)
    {
        foreach (var color in gameSet.Split(','))
        {
            var colorValue = GetNumberOfCubes(color);
            if (color.Contains(BLUE_TEXT))
            {
                cubeGame.UpdateBlueMinimumValue(colorValue);
            }
            if (color.Contains(RED_TEXT))
            {
                cubeGame.UpdateRedMinimumValue(colorValue);
            }
            if (color.Contains(GREEN_TEXT))
            {
                cubeGame.UpdateGreenMinimumValue(colorValue);
            }
        }
    }
}
