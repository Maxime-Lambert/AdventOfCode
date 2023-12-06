using AdventOfCode._2023.Day3;

namespace AdventOfCodeTests._2023.Day3;

public class UnitTestsEngineChecker
{
    [Fact]
    public void EngineChecker_Part1_Should_Return_4361()
    {
        //Arrange
        string[] engineSchematic = ["467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.."];

        //Act
        var result = EngineChecker.SumEngineValidParts(engineSchematic);

        //Assert
        result.Should().Be(4361);
    }

    [Fact]
    public void EngineChecker_Part1_EdgeNumbers_Should_Return_4361()
    {
        //Arrange
        string[] engineSchematic = [".....114..",
            "...*......",
            "..35..633.",
            "......#467",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.."];

        //Act
        var result = EngineChecker.SumEngineValidParts(engineSchematic);

        //Assert
        result.Should().Be(4361);
    }

    [Fact]
    public void EngineChecker_Part2_Should_Return_467835()
    {
        //Arrange
        string[] engineSchematic = ["467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.."];

        //Act
        var result = EngineChecker.SumGearRatios(engineSchematic);

        //Assert
        result.Should().Be(467835);
    }

    [Fact]
    public void EngineChecker_Part2_EdgeGear_Should_Return_467835()
    {
        //Arrange
        string[] engineSchematic = ["467..114..",
            "*.........",
            ".35...633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.."];

        //Act
        var result = EngineChecker.SumGearRatios(engineSchematic);

        //Assert
        result.Should().Be(467835);
    }

    [Fact]
    public void EngineChecker_Part2_3Numbers_Should_Return_451490()
    {
        //Arrange
        string[] engineSchematic = ["467..114..",
            "*80.......",
            ".35...633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.."];

        //Act
        var result = EngineChecker.SumGearRatios(engineSchematic);

        //Assert
        result.Should().Be(451490);
    }

    [Fact]
    public void EngineChecker_Part2_EdgeCases_Should_Return_451490()
    {
        //Arrange
        string[] engineSchematic = ["1*1......1",
            ".........*",
            ".........1",
            "1.........",
            ".*........",
            "..1.......",
            "...1....1.",
            "..*....*..",
            ".111*1*1*1",
            ".........."];

        //Act
        var result = EngineChecker.SumGearRatios(engineSchematic);

        //Assert
        result.Should().Be(228);
    }
}
