using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day5;

public static class SeedLocationFinder
{
    private static readonly string patternDecimal = @"\d";
    private static readonly List<IntegerMap> _seedToSoil = [];
    private static readonly List<IntegerMap> _soilToFertilizer = [];
    private static readonly List<IntegerMap> _fertilizerToWater = [];
    private static readonly List<IntegerMap> _waterToLight = [];
    private static readonly List<IntegerMap> _lightToTemperature = [];
    private static readonly List<IntegerMap> _temperatureToHumidity = [];
    private static readonly List<IntegerMap> _humidityToLocation = [];

    public static BigInteger SolveSeedLocationPart1(string filePath)
    {
        return GetLowestLocationPart1(File.ReadAllLines(Path.GetFullPath(filePath)));
    }

    public static BigInteger GetLowestLocationPart1(string[] almanac)
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

        return seedList.Select(seed => BigInteger.Parse(seed))
            .Select(seed => GetNextMapValue(seed, _seedToSoil))
            .Select(soil => GetNextMapValue(soil, _soilToFertilizer))
            .Select(fertilizer => GetNextMapValue(fertilizer, _fertilizerToWater))
            .Select(water => GetNextMapValue(water, _waterToLight))
            .Select(light => GetNextMapValue(light, _lightToTemperature))
            .Select(temperature => GetNextMapValue(temperature, _temperatureToHumidity))
            .Select(humidity => GetNextMapValue(humidity, _humidityToLocation))
            .Min();
    }

    private static int ExtractNextMap(string[] almanac, int lineCounter, List<IntegerMap> map)
    {
        while (lineCounter < almanac.Length && Regex.IsMatch(almanac[lineCounter], patternDecimal))
        {
            var splittedLine = almanac[lineCounter].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var destinationRangeStart = BigInteger.Parse(splittedLine[0]);
            var sourceRangeStart = BigInteger.Parse(splittedLine[1]);
            var range = BigInteger.Parse(splittedLine[2]);
            map.Add(new IntegerMap(destinationRangeStart, sourceRangeStart, range));
            lineCounter++;
        }
        return lineCounter + 2;
    }
    
    private static BigInteger GetNextMapValue(BigInteger source, List<IntegerMap> map)
    {
        var x = map.FirstOrDefault(a => a.SourceRangeStart <= source && source <= a.SourceRangeStart + a.Range);
        if (x is null)
        {
            return source;
        }
        return x.DestinationRangeStart + source - x.SourceRangeStart;
    }

  
}
