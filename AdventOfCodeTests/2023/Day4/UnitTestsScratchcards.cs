using AdventOfCode._2023.Day4;

namespace AdventOfCodeTests._2023.Day4;

public class UnitTestsScratchcards
{
    [Fact]
    public void Scratchcards_Part1_Card1_Should_Return_8()
    {
        //Arrange
        const string cardValues = "41 48 83 86 17 | 83 86  6 31 17  9 48 53";

        //Act
        var result = Scratchcards.GetPoints(cardValues);

        //Assert
        result.Should().Be(8);
    }

    [Fact]
    public void Scratchcards_Part1_Card2_Should_Return_2()
    {
        //Arrange
        const string cardValues = "13 32 20 16 61 | 61 30 68 82 17 32 24 19";

        //Act
        var result = Scratchcards.GetPoints(cardValues);

        //Assert
        result.Should().Be(2);
    }

    [Fact]
    public void Scratchcards_Part1_Card3_Should_Return_2()
    {
        //Arrange
        const string cardValues = "1 21 53 59 44 | 69 82 63 72 16 21 14  1";

        //Act
        var result = Scratchcards.GetPoints(cardValues);

        //Assert
        result.Should().Be(2);
    }

    [Fact]
    public void Scratchcards_Part1_Card4_Should_Return_1()
    {
        //Arrange
        const string cardValues = "41 92 73 84 69 | 59 84 76 51 58  5 54 83";

        //Act
        var result = Scratchcards.GetPoints(cardValues);

        //Assert
        result.Should().Be(1);
    }

    [Fact]
    public void Scratchcards_Part1_Card5_Should_Return_0()
    {
        //Arrange
        const string cardValues = "87 83 26 28 32 | 88 30 70 12 93 22 82 36";

        //Act
        var result = Scratchcards.GetPoints(cardValues);

        //Assert
        result.Should().Be(0);
    }

    [Fact]
    public void Scratchcards_Part1_Card6_Should_Return_0()
    {
        //Arrange
        const string cardValues = "31 18 13 56 72 | 74 77 10 23 35 67 36 11";

        //Act
        var result = Scratchcards.GetPoints(cardValues);

        //Assert
        result.Should().Be(0);
    }

    [Fact]
    public void Scratchcards_Part2_Should_Return_30()
    {
        //Arrange
        string[] cardValues = ["Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"];

        //Act
        var result = Scratchcards.GetNumberOfCopies(cardValues);

        //Assert
        result.Should().Be(30);
    }
}
