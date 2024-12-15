using AdventOfCode.ProblemSolvers._2024.Day4;
using AdventOfCode.ProblemSolvers._2024.Day6;

namespace AdventOfCodeTests._2024.Day6;
public class UnitTestsGuardGallivant
{
    [Fact]
    public void GearRatios_Part1_Should_Return_4361()
    {
        //Arrange
        string[] labMap = [ "....#.....",
                            ".........#",
                            "..........",
                            "..#.......",
                            ".......#..",
                            "..........",
                            ".#..^.....",
                            "........#.",
                            "#.........",
                            "......#..."];

        //Act
        var result = GuardGallivant.NumberOfDifferentCasesPatrolled(labMap);

        //Assert
        result.Should().Be(41);
    }
}
