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
}
