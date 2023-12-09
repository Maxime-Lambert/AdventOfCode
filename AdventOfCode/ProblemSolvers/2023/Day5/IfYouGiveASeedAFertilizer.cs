using System.Text.RegularExpressions;

using AdventOfCode.InputReader;
using AdventOfCode.ProblemSolvers;

namespace AdventOfCode._2023.Day5;

public sealed class IfYouGiveASeedAFertilizer(IReadInputs inputReader) : ProblemSolver(inputReader)
{
    private const string INPUT_FILE_NAME = "InputDay5.txt";

    private const string PATTERN_NUMBERS = @"\d";

    private static readonly List<List<LongMapWithRange>> _mapsList = [];

    public override long SolvePart1()
    {
        return GetLowestLocationPart1(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public override long SolvePart2()
    {
        return GetLowestLocationPart2(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public static long GetLowestLocationPart1(string[] almanac)
    {
        var seedList = almanac[0].Split(':')[1]
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(seed => new SeedRange(long.Parse(seed), 0, true)).ToList();

        ExtractMaps(almanac);

        seedList = GetLocations(seedList);

        return seedList.Min(seedRange => seedRange.Seed);
    }

    private static List<SeedRange> GetLocations(List<SeedRange> seedList)
    {
        _mapsList.ForEach(maps =>
        {
            foreach (var map in maps)
            {
                seedList = map.MapSeedRangesPart1(seedList);
            }
            foreach (var seedRange in seedList)
            {
                seedRange.ToMapNext = true;
            }
        });
        return seedList;
    }

    private static void ExtractMaps(string[] almanac)
    {
        _mapsList.Clear();
        var lineCounter = 3;
        var actualMap = new List<LongMapWithRange>();
        while (lineCounter < almanac.Length)
        {
            var inputLine = almanac[lineCounter];
            if (Regex.IsMatch(inputLine, PATTERN_NUMBERS))
            {
                var splittedLine = inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var destinationRangeStart = long.Parse(splittedLine[0]);
                var sourceRangeStart = long.Parse(splittedLine[1]);
                var range = long.Parse(splittedLine[2]);
                actualMap.Add(new LongMapWithRange(destinationRangeStart, sourceRangeStart, range));
            }
            else if (inputLine.Length > 0)
            {
                _mapsList.Add(actualMap);
                actualMap = [];
            }
            lineCounter++;
        }
        _mapsList.Add(actualMap);
    }

    public static long GetLowestLocationPart2(string[] almanac)
    {
        var seedInformations = almanac[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        var seedList = new List<SeedRange>();
        for (int i = 0; i < seedInformations.Count; i += 2)
        {
            seedList.Add(new SeedRange(long.Parse(seedInformations[i]), long.Parse(seedInformations[i + 1]), true));
        }

        ExtractMaps(almanac);

        seedList = GetLocationsPart2(seedList);

        return seedList.Min(seedRange => seedRange.Seed);
    }

    private static List<SeedRange> GetLocationsPart2(List<SeedRange> seedList)
    {
        _mapsList.ForEach(maps =>
        {
            foreach (var map in maps)
            {
                seedList = map.MapSeedRangesPart2(seedList);
            }
            foreach (var seedRange in seedList)
            {
                seedRange.ToMapNext = true;
            }
        });
        return seedList;
    }
}
