using AdventOfCode.ProblemSolvers._2023.Day10;

namespace AdventOfCodeTests._2023.Day10;

public class UnitTestsPipeMaze
{
    [Fact]
    public void PipeMaze_Tile1_Should_Return_4()
    {
        //Arrange
        string[] tile = [
            "-L|F7",
            "7S-7|",
            "L|7||",
            "-L-J|",
            "L|-JF"];

        //Act
        var result = PipeMaze.FurthestDistanceInLoopFromS(tile);

        //Assert
        result.Should().Be(4);
    }

    [Fact]
    public void PipeMaze_Tile2_Should_Return_8()
    {
        //Arrange
        string[] tile = [
            "7-F7-",
            ".FJ|7",
            "SJLL7",
            "|F--J",
            "LJ.LJ"];

        //Act
        var result = PipeMaze.FurthestDistanceInLoopFromS(tile);

        //Assert
        result.Should().Be(8);
    }
}
