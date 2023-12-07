using System.Reflection.Metadata;

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

    public static int SolveCamelCardsPart2(string filePath)
    {
        return SolveHandsPart2(File.ReadAllLines(Path.GetFullPath(filePath)));
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

    public static int SolveHandsPart2(string[] inputLines)
    {
        ExtractHandsAndBids(inputLines);

        var result = 0;
        var a = new Dictionary<string, int>();
        for (int i = 0; i < _hands.Count; i++)
        {
            var x = GetHandRankPart2(_hands[i]);
            a.Add(_hands[i], x);
            result += x * _bids[i];
        }

        return result;
    }

    private static void ExtractHandsAndBids(string[] hands)
    {
        _hands.Clear();
        _bids.Clear();
        foreach (var hand in hands)
        {
            var splittedHand = hand.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            _hands.Add(splittedHand[0]);
            _bids.Add(int.Parse(splittedHand[1]));
        }
    }

    private static int GetHandRank(string hand)
    {
        return _hands.Sum(card => CompareTwoHands(hand, card) ? 1 : 0) + 1;
    }

    private static int GetHandRankPart2(string hand)
    {
        return _hands.Sum(currentHand => CompareTwoHandsPart2(hand, currentHand) ? 1 : 0) + 1;
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
    private static bool CompareTwoHandsPart2(string hand1, string hand2)
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
        var hand1Type = GetHandTypePart2(hand1CardsCount);
        var hand2Type = GetHandTypePart2(hand2CardsCount);

        if (Enum.Equals(hand1Type, hand2Type))
        {
            for (int i = 0; i < hand1.Length; i++)
            {
                var charComparison = _pokerComparer.ComparePart2(hand1[i], hand2[i]);
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
    
    private static HandTypes GetHandTypePart2(Dictionary<char, int> cardsCount)
    {
        var numberOfJokers = cardsCount.GetValueOrDefault('J');
        if(numberOfJokers == 5)
        {
            return HandTypes.FiveOfAKind;
        }
        var distinctCardsNumber = cardsCount.Count;
        if (numberOfJokers > 0)
        {
            distinctCardsNumber--;
        }
        if (distinctCardsNumber == 5)
        {
            return HandTypes.HighCard;
        }
        if (distinctCardsNumber == 4)
        {
            return HandTypes.OnePair;
        }
        if (distinctCardsNumber == 3)
        {
            if (cardsCount.Values.Max() + numberOfJokers == 3 || numberOfJokers == 2)
            {
                return HandTypes.ThreeOfAKind;
            }
            return HandTypes.TwoPair;
        }
        if (distinctCardsNumber == 2)
        {
            if (cardsCount.Values.Max() + numberOfJokers == 4 || numberOfJokers == 3)
            {
                return HandTypes.FourOfAKind;
            }
            return HandTypes.FullHouse;
        }
        return HandTypes.FiveOfAKind;
    }
}
