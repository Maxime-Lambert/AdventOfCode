namespace AdventOfCode._2023.Day5;

internal class SeedRange(long Seed, long Range, bool ToMapNext)
{
    public long Seed { get; init; } = Seed;

    public long Range { get; init; } = Range;

    public bool ToMapNext { get; set; } = ToMapNext;
};
