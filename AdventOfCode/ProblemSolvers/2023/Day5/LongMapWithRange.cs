namespace AdventOfCode._2023.Day5;

internal class LongMapWithRange(long destinationRangeStart, long sourceRangeStart, long range)
{
    public long DestinationRangeStart { get; init; } = destinationRangeStart;
    public long SourceRangeStart { get; init; } = sourceRangeStart;
    public long Range { get; init; } = range;

    public SeedRange MapSeedRange(SeedRange source)
    {
        if (source.ToMapNext)
        {
            if (SourceRangeStart <= source.Seed && source.Seed <= SourceRangeStart + Range)
            {
                return new SeedRange(DestinationRangeStart + (source.Seed - SourceRangeStart), 0, false);
            }
        }
        return source;
    }
    public List<SeedRange> MapSeedRangesPart1(List<SeedRange> seedRanges)
    {
        var seedRangeResult = new List<SeedRange>();
        foreach (SeedRange range in seedRanges)
        {
            seedRangeResult.Add(MapSeedRange(range));
        }
        return seedRangeResult;
    }

    public List<SeedRange> MapSeedRangesPart2(List<SeedRange> seedRanges)
    {
        var seedRangeResult = new List<SeedRange>();
        foreach (SeedRange range in seedRanges)
        {
            seedRangeResult.AddRange(mapSeedRange(range));
        }
        return seedRangeResult;
    }

    private List<SeedRange> mapSeedRange(SeedRange seedRange)
    {
        var seedRangeResult = new List<SeedRange>();
        if (IsWholeSeedOutsideOfMap(seedRange) || !seedRange.ToMapNext)
        {
            seedRangeResult.Add(seedRange);
        }
        else if (IsSeedStartAfterSourceStart(seedRange))
        {
            var seedOffset = seedRange.Seed - SourceRangeStart;
            if (seedRange.Seed + seedRange.Range < SourceRangeStart + Range)
            {
                seedRangeResult.Add(new SeedRange(DestinationRangeStart + seedOffset, seedRange.Range, false));
            }
            else
            {
                seedRangeResult.Add(new SeedRange(DestinationRangeStart + seedOffset, SourceRangeStart + Range - seedRange.Seed, false));
                seedRangeResult.Add(new SeedRange(SourceRangeStart + Range, seedRange.Seed + seedRange.Range - (SourceRangeStart + Range), true));
            }
        }
        else
        {
            if (seedRange.Seed + seedRange.Range >= SourceRangeStart + Range)
            {
                seedRangeResult.Add(new SeedRange(seedRange.Seed, SourceRangeStart - seedRange.Seed, true));
                seedRangeResult.Add(new SeedRange(DestinationRangeStart, Range, false));
                seedRangeResult.Add(new SeedRange(SourceRangeStart + Range, seedRange.Seed + seedRange.Range - (SourceRangeStart + Range), true));
            }
            else
            {
                seedRangeResult.Add(new SeedRange(seedRange.Seed, SourceRangeStart - seedRange.Seed, true));
                seedRangeResult.Add(new SeedRange(DestinationRangeStart, (seedRange.Seed + seedRange.Range) - SourceRangeStart, false));
            }
        }
        return seedRangeResult;
    }

    private bool IsSeedStartAfterSourceStart(SeedRange seedRange)
    {
        return seedRange.Seed >= SourceRangeStart && seedRange.Seed < SourceRangeStart + Range;
    }

    private bool IsWholeSeedOutsideOfMap(SeedRange seedRange)
    {
        return (seedRange.Seed + seedRange.Range < SourceRangeStart) || (seedRange.Seed > SourceRangeStart + Range);
    }
}
