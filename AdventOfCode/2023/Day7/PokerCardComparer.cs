namespace AdventOfCode._2023.Day7;

internal class PokerCardComparer : IComparer<char>
{

    public PokerCardComparer()
    {

    }

    public int Compare(char x, char y)
    {
        if (x == y) return 0;

        if (x == 'A') return 1;

        if (y == 'A') return -1;

        if (x == 'K') return 1;

        if (y == 'K') return -1;

        if (x == 'Q') return 1;

        if (y == 'Q') return -1;

        if (x == 'J') return 1;

        if (y == 'J') return -1;

        if (x == 'T') return 1;

        if (y == 'T') return -1;

        return (x - y);
    }

    public int ComparePart2(char x, char y)
    {
        if (x == y) return 0;

        if (x == 'A') return 1;

        if (y == 'A') return -1;

        if (x == 'J') return -1;

        if (y == 'J') return 1;

        if (x == 'K') return 1;

        if (y == 'K') return -1;

        if (x == 'Q') return 1;

        if (y == 'Q') return -1;

        if (x == 'T') return 1;

        if (y == 'T') return -1;

        return (x - y);
    }
}
