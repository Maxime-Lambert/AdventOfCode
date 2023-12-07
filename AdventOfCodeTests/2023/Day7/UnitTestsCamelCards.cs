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
}
