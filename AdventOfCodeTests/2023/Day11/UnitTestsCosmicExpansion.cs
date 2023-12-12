using AdventOfCode.ProblemSolvers._2023.Day11;

namespace AdventOfCodeTests._2023.Day11;

public class UnitTestsCosmicExpansion
{
    [Fact]
    public void CosmicExpansion_Should_Return_374()
    {
        //Arrange
        string[] image = [
            "...#......",
            ".......#..",
            "#.........",
            "..........",
            "......#...",
            ".#........",
            ".........#",
            "..........",
            ".......#..",
            "#...#....."];
        
        //Act
        var result = CosmicExpansion.GetSumOfShortestPathsBetweenGalaxies(image);

        //Assert
        result.Should().Be(374);
    }
}
