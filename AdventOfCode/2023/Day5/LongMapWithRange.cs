namespace AdventOfCode._2023.Day5;

internal class LongMapWithRange(long destinationRangeStart, long sourceRangeStart, long range)
{
    public long DestinationRangeStart { get; init; } = destinationRangeStart;
    public long SourceRangeStart { get; init; } = sourceRangeStart;
    public long Range { get; init; } = range;

    private long MapLong(long source)
    {
        if (SourceRangeStart <= source && source <= SourceRangeStart + Range)
        {
            return DestinationRangeStart + (source - SourceRangeStart);
        } else
        {
            return source;
        }
    }

    public List<SeedRange> MapSeedRanges(List<SeedRange> seedRanges)
    {
        var seedRangeResult = new List<SeedRange>();
        foreach(SeedRange range in seedRanges)
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
