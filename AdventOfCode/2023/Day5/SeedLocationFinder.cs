using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day5;

public static class SeedLocationFinder
{
    private static readonly string _patternDecimal = @"\d";
    private static readonly List<LongMapWithRange> _seedToSoil = [];
    private static readonly List<LongMapWithRange> _soilToFertilizer = [];
    private static readonly List<LongMapWithRange> _fertilizerToWater = [];
    private static readonly List<LongMapWithRange> _waterToLight = [];
    private static readonly List<LongMapWithRange> _lightToTemperature = [];
    private static readonly List<LongMapWithRange> _temperatureToHumidity = [];
    private static readonly List<LongMapWithRange> _humidityToLocation = [];

    public static long SolveSeedLocationPart1(string filePath)
    {
        return GetLowestLocationPart1(File.ReadAllLines(Path.GetFullPath(filePath)));
    }

    public static long SolveSeedLocationPart2(string filePath)
    {
        return GetLowestLocationPart2(File.ReadAllLines(Path.GetFullPath(filePath)));
    }

    public static long GetLowestLocationPart1(string[] almanac)
    {
        var seedList = almanac[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var lineCounter = 3;
        lineCounter = ExtractNextMap(almanac, lineCounter, _seedToSoil);
        lineCounter = ExtractNextMap(almanac, lineCounter, _soilToFertilizer);
        lineCounter = ExtractNextMap(almanac, lineCounter, _fertilizerToWater);
        lineCounter = ExtractNextMap(almanac, lineCounter, _waterToLight);
        lineCounter = ExtractNextMap(almanac, lineCounter, _lightToTemperature);
        lineCounter = ExtractNextMap(almanac, lineCounter, _temperatureToHumidity);
        _ = ExtractNextMap(almanac, lineCounter, _humidityToLocation);

        return seedList.Select(seed => long.Parse(seed))
            .Select(seed => GetNextMapValue(seed, _seedToSoil))
            .Select(soil => GetNextMapValue(soil, _soilToFertilizer))
            .Select(fertilizer => GetNextMapValue(fertilizer, _fertilizerToWater))
            .Select(water => GetNextMapValue(water, _waterToLight))
            .Select(light => GetNextMapValue(light, _lightToTemperature))
            .Select(temperature => GetNextMapValue(temperature, _temperatureToHumidity))
            .Select(humidity => GetNextMapValue(humidity, _humidityToLocation))
            .Min();
    }

    public static long GetLowestLocationPart2(string[] almanac)
    {
        var seedInformations = almanac[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        var seedList = new List<SeedRange>();
        for (int i = 0; i < seedInformations.Count; i+=2)
        {
            seedList.Add(new SeedRange(long.Parse(seedInformations[i]), long.Parse(seedInformations[i+1]), true));
        }

        var lineCounter = 3;
        lineCounter = ExtractNextMap(almanac, lineCounter, _seedToSoil);
        lineCounter = ExtractNextMap(almanac, lineCounter, _soilToFertilizer);
        lineCounter = ExtractNextMap(almanac, lineCounter, _fertilizerToWater);
        lineCounter = ExtractNextMap(almanac, lineCounter, _waterToLight);
        lineCounter = ExtractNextMap(almanac, lineCounter, _lightToTemperature);
        lineCounter = ExtractNextMap(almanac, lineCounter, _temperatureToHumidity);
        _ = ExtractNextMap(almanac, lineCounter, _humidityToLocation);

        var Maps = new List<List<LongMapWithRange>>
        {
            _seedToSoil,
            _soilToFertilizer,
            _fertilizerToWater,
            _waterToLight,
            _lightToTemperature,
            _temperatureToHumidity,
            _humidityToLocation
        };

        Maps.ForEach(maps =>
        {
            foreach (var map in maps)
            {
                seedList = map.MapSeedRanges(seedList);
            }
            foreach (var seedRange in seedList)
            {
                seedRange.ToMapNext = true;
            }
        });

        return seedList.Min(seedRange => seedRange.Seed);
    }

    private static int ExtractNextMap(string[] almanac, int lineCounter, List<LongMapWithRange> map)
    {
        while (lineCounter < almanac.Length && Regex.IsMatch(almanac[lineCounter], _patternDecimal))
        {
            var splittedLine = almanac[lineCounter].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var destinationRangeStart = long.Parse(splittedLine[0]);
            var sourceRangeStart = long.Parse(splittedLine[1]);
            var range = long.Parse(splittedLine[2]);
            map.Add(new LongMapWithRange(destinationRangeStart, sourceRangeStart, range));
            lineCounter++;
        }
        return lineCounter + 2;
    }

    private static long GetNextMapValue(long source, List<LongMapWithRange> map)
    {
        var x = map.FirstOrDefault(a => a.SourceRangeStart <= source && source <= a.SourceRangeStart + a.Range);
        if (x is null)
        {
            return source;
        }
        return x.DestinationRangeStart + source - x.SourceRangeStart;
    }


}
