using AdventOfCode._2023.Day7;

namespace AdventOfCodeTests._2023.Day7;
public class UnitTestsCamelCards
{
    [Fact]
    public void Camel_Cards_Part1_Should_Return_6440()
    {
        //Arrange
        string[] hands = ["32T3K 765",
            "T55J5 684",
            "KK677 28",
            "KTJJT 220",
            "QQQJA 483"];

        //Act
        var result = CamelCards.SolveHandsPart1(hands);

        //Assert
        result.Should().Be(6440);
    }

    [Fact]
    public void Camel_Cards_Part2_Should_Return_5905()
    {
        //Arrange
        string[] hands = ["32T3K 765",
            "T55J5 684",
            "KK677 28",
            "KTJJT 220",
            "QQQJA 483"];

        //Act
        var result = CamelCards.SolveHandsPart2(hands);

        //Assert
        result.Should().Be(5905);
    }

    [Fact]
    public void Camel_Cards_Part2_EdgeCases_Should_Return_5905()
    {
        // 1 3 2 5 4

        //Arrange
        string[] hands = ["27A83 765",
            "Q2KJJ 684",
            "KK677 28",
            "AAAAA 220",
            "99999 483"];

        //Act
        var result = CamelCards.SolveHandsPart2(hands);

        //Assert
        result.Should().Be(5905);
    }

    [Fact]
    public void Camel_Cards_Part2_EdgeCases_Comparator_Should_Return_5905()
    {
        // 1 3 2 5 4

        //Arrange
        string[] hands = ["27A83 765",
            "77888 684",
            "77788 28",
            "33332 220",
            "2AAAA 483"];

        //Act
        var result = CamelCards.SolveHandsPart2(hands);

        //Assert
        result.Should().Be(5905);
    }

    [Fact]
    public void Camel_Cards_Part2_EdgeCases_Comparator_With_Jokers_Should_Return_5905()
    {
        // 1 3 2 5 4

        //Arrange
        string[] hands = ["27A8J 765",
            "8877J 684",
            "778J8 28",
            "333J2 220",
            "2AJJJ 483"];

        //Act
        var result = CamelCards.SolveHandsPart2(hands);

        //Assert
        result.Should().Be(5905);
    }
}
