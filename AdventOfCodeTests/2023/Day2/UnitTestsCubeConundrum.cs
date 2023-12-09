using AdventOfCode._2023.Day2;

namespace AdventOfCodeTests._2023.Day2;

public class UnitTestsCubeConundrum
{
    [Fact]
    public void CubeConundrum_Part1_Game1_Should_Return_True()
    {
        //Arrange
        const string gameValues = "3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";

        //Act
        var result = CubeConundrum.AreAllGamesPossible(gameValues);

        //Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void CubeConundrum_Part1_Game2_Should_Return_True()
    {
        //Arrange
        const string gameValues = "1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue";

        //Act
        var result = CubeConundrum.AreAllGamesPossible(gameValues);

        //Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void CubeConundrum_Part1_Game3_Should_Return_False()
    {
        //Arrange
        const string gameValues = "8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red";

        //Act
        var result = CubeConundrum.AreAllGamesPossible(gameValues);

        //Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void CubeConundrum_Part1_Game4_Should_Return_False()
    {
        //Arrange
        const string gameValues = "1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red";

        //Act
        var result = CubeConundrum.AreAllGamesPossible(gameValues);

        //Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void CubeConundrum_Part1_Game5_Should_Return_True()
    {
        //Arrange
        const string gameValues = "6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";

        //Act
        var result = CubeConundrum.AreAllGamesPossible(gameValues);

        //Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void CubeConundrum_Part2_Game1_Should_Return_48()
    {
        //Arrange
        const string gameValues = "3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";

        //Act
        var result = CubeConundrum.GetProductOfMinimumValueForEachColor(gameValues);

        //Assert
        result.Should().Be(48);
    }

    [Fact]
    public void CubeConundrum_Part2_Game2_Should_Return_12()
    {
        //Arrange
        const string gameValues = "1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue";

        //Act
        var result = CubeConundrum.GetProductOfMinimumValueForEachColor(gameValues);

        //Assert
        result.Should().Be(12);
    }

    [Fact]
    public void CubeConundrum_Part2_Game3_Should_Return_1560()
    {
        //Arrange
        const string gameValues = "8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red";

        //Act
        var result = CubeConundrum.GetProductOfMinimumValueForEachColor(gameValues);

        //Assert
        result.Should().Be(1560);
    }

    [Fact]
    public void CubeConundrum_Part2_Game4_Should_Return_630()
    {
        //Arrange
        const string gameValues = "1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red";

        //Act
        var result = CubeConundrum.GetProductOfMinimumValueForEachColor(gameValues);

        //Assert
        result.Should().Be(630);
    }

    [Fact]
    public void CubeConundrum_Part2_Game5_Should_Return_36()
    {
        //Arrange
        const string gameValues = "6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";

        //Act
        var result = CubeConundrum.GetProductOfMinimumValueForEachColor(gameValues);

        //Assert
        result.Should().Be(36);
    }
}
