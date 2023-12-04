using AdventOfCode._2023.Day2;

namespace AdventOfCodeTests._2023.Day2;
public class UnitTestsCubeConundrum
{
    [Fact]
    public void CubeGameSolver_Part1_Game1_Should_Return_True()
    {
        //Arrange
        const string game1Values = "3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";

        //Act
        var result = CubeGameSolver.SolveGame(game1Values);

        //Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void CubeGameSolver_Part1_Game2_Should_Return_True()
    {
        //Arrange
        const string game1Values = "1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue";

        //Act
        var result = CubeGameSolver.SolveGame(game1Values);

        //Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void CubeGameSolver_Part1_Game3_Should_Return_False()
    {
        //Arrange
        const string game1Values = "8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red";

        //Act
        var result = CubeGameSolver.SolveGame(game1Values);

        //Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void CubeGameSolver_Part1_Game4_Should_Return_False()
    {
        //Arrange
        const string game1Values = "1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red";

        //Act
        var result = CubeGameSolver.SolveGame(game1Values);

        //Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void CubeGameSolver_Part1_Game5_Should_Return_True()
    {
        //Arrange
        const string game1Values = "6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";

        //Act
        var result = CubeGameSolver.SolveGame(game1Values);

        //Assert
        result.Should().BeTrue();
    }
}
