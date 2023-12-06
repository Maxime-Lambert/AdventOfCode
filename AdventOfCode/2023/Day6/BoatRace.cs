using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2023.Day6;

public static class BoatRace
{
    public static int SolveBoatRacePart1(string filePath)
    {
        var fileLines = File.ReadAllLines(Path.GetFullPath(filePath)).ToList();
        var timesList = fileLines[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        var distanceList = fileLines[1].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        var result = 1;
        for(int i = 0; i < timesList.Count; i++)
        {
            result *= NumberOfWinningWays(timesList[i], distanceList[i]);
        }
        return result;
    }

    public static int NumberOfWinningWays(int time, int recordDistance)
    {
        var numberOfWinningWays = 0;
        for(int i = 1; i < time; i++)
        {
            if((time - i) * i > recordDistance)
            {
                numberOfWinningWays++;
            }
        }
        return numberOfWinningWays;
    }
}
