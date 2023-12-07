namespace AdventOfCode._2023.Day7;

public static class CamelCards
{
    private static readonly List<string> _hands = [];
    private static readonly List<int> _bids = [];
    private static readonly PokerCardComparer _pokerComparer = new();

    public static int SolveCamelCardsPart1(string filePath)
    {
        return SolveHandsPart1(File.ReadAllLines(Path.GetFullPath(filePath)));
    }

    public static int SolveHandsPart1(string[] inputLines)
    {
        ExtractHandsAndBids(inputLines);

        var result = 0;
        for (int i = 0; i < _hands.Count; i++)
        {
            result += GetHandRank(_hands[i]) * _bids[i];
        }

        return result;
    }

    private static int GetHandRank(string hand)
    {
        return _hands.Sum(card => CompareTwoHands(hand, card) ? 1 : 0) + 1;
    }

    private static void ExtractHandsAndBids(string[] hands)
    {
        foreach (var hand in hands)
        {
            var splittedHand = hand.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            _hands.Add(splittedHand[0]);
            _bids.Add(int.Parse(splittedHand[1]));
        }
    }

    private static bool CompareTwoHands(string hand1, string hand2)
    {
        var hand1CardsCount = new Dictionary<char, int>();
        var hand2CardsCount = new Dictionary<char, int>();
        for (int i = 0; i < hand1.Length; i++)
        {
            if (!hand1CardsCount.TryAdd(hand1[i], 1))
            {
                hand1CardsCount[hand1[i]] += 1;
            }
            if (!hand2CardsCount.TryAdd(hand2[i], 1))
            {
                hand2CardsCount[hand2[i]] += 1;
            }
        }
        var hand1Type = GetHandType(hand1CardsCount);
        var hand2Type = GetHandType(hand2CardsCount);

        if (Enum.Equals(hand1Type, hand2Type))
        {
            for (int i = 0; i < hand1.Length; i++)
            {
                var charComparison = _pokerComparer.Compare(hand1[i], hand2[i]);
                if (charComparison > 0) return true;
                if (charComparison < 0) return false;
            }
        }
        if (hand1Type > hand2Type)
        {
            return true;
        }
        return false;

    }

    private static HandTypes GetHandType(Dictionary<char, int> cardsCount)
    {
        if (cardsCount.Count == 5)
        {
            return HandTypes.HighCard;
        }
        if (cardsCount.Count == 4)
        {
            return HandTypes.OnePair;
        }
        if (cardsCount.Count == 3)
        {
            if (cardsCount.Values.Max() == 3)
            {
                return HandTypes.ThreeOfAKind;
            }
            else
            {
                return HandTypes.TwoPair;
            }
        }
        if (cardsCount.Count == 2)
        {
            if (cardsCount.Values.Max() == 4)
            {
                return HandTypes.FourOfAKind;
            }
            else
            {
                return HandTypes.FullHouse;
            }
        }
        return HandTypes.FiveOfAKind;
    }
}
