using AdventOfCode.ProblemSolvers._2023.Day14;

namespace AdventOfCodeTests._2023.Day14;

public class UnitTestsParabolicReflectorDish
{
    [Fact]
    public void ParabolicReflectorDish_Should_Return_136()
    {
        //Arrange
        string[] platform = [
            "O....#....",
            "O.OO#....#",
            ".....##...",
            "OO.#O....O",
            ".O.....O#.",
            "O.#..O.#.#",
            "..O..#O..O",
            ".......O..",
            "#....###..",
            "#OO..#...."];

        //Act
        var result = ParabolicReflectorDish.SumOfTotalLoads(platform);

        //Assert
        result.Should().Be(136);
    }
}
