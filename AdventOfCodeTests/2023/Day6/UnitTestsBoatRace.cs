using AdventOfCode._2023.Day6;

namespace AdventOfCodeTests._2023.Day6;
public class UnitTestsBoatRace
{
    [Fact]
    public static void BoatRace_Race1_Should_Be_4()
    {
        //Arrange
        const int time = 7;
        const int distance = 9;

        //Act
        var result = BoatRace.NumberOfWinningWays(time, distance);

        //Assert
        result.Should().Be(4);
    }

    [Fact]
    public static void BoatRace_Race2_Should_Be_8()
    {
        //Arrange
        const int time = 15;
        const int distance = 40;

        //Act
        var result = BoatRace.NumberOfWinningWays(time, distance);

        //Assert
        result.Should().Be(8);
    }

    [Fact]
    public static void BoatRace_Race3_Should_Be_9()
    {
        //Arrange
        const int time = 30;
        const int distance = 200;

        //Act
        var result = BoatRace.NumberOfWinningWays(time, distance);

        //Assert
        result.Should().Be(9);
    }

    [Fact]
    public static void BoatRace_Part2_Race_Should_Be_71503()
    {
        //Arrange
        const int time = 71530;
        const int distance = 940200;

        //Act
        var result = BoatRace.NumberOfWinningWays(time, distance);

        //Assert
        result.Should().Be(71503);
    }
}
