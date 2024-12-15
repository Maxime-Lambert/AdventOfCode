using AdventOfCode.ProblemSolvers._2024.Day4;

namespace AdventOfCodeTests._2024.Day4;

public class UnitTestsCeresSearch
{
    [Fact]
    public void GearRatios_Part1_Should_Return_4361()
    {
        //Arrange
        string[] engineSchematic = ["MMMSXXMASM",
            "MSAMXMSMSA",
            "AMXSXMAAMM",
            "MSAMASMSMX",
            "XMASAMXAMM",
            "XXAMMXXAMA",
            "SMSMSASXSS",
            "SAXAMASAAA",
            "MAMMMXMMMM",
            "MXMXAXMASX"];

        //Act
        var result = CeresSearch.XmasWordSearch(engineSchematic);

        //Assert
        result.Should().Be(18);
    }
}
