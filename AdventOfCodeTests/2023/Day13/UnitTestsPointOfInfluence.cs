using AdventOfCode.ProblemSolvers._2023.Day13;

namespace AdventOfCodeTests._2023.Day13;

public class UnitTestsPointOfInfluence
{
    [Fact]
    public void PointOfInfluence_Pattern1_Should_Return_5()
    {
        //Arrange
        string[] pattern = [
            "#.##..##.",
            "..#.##.#.",
            "##......#",
            "##......#",
            "..#.##.#.",
            "..##..##.",
            "#.#.##.#."];
        //Act
        var result = PointOfIncidence.FindReflectionAndAddColumns(pattern);

        //Assert
        result.Should().Be(5);
    }

    [Fact]
    public void PointOfInfluence_Pattern3_Should_Return_4()
    {
        //Arrange
        string[] pattern = [
            ".#.##.#.#",
            ".##..##..",
            ".#.##.#..",
            "#......##",
            "#......##",
            ".#.##.#..",
            ".##..##.#"];
        //Act
        var result = PointOfIncidence.FindReflectionAndAddColumns(pattern);

        //Assert
        result.Should().Be(4);
    }

    [Fact]
    public void PointOfInfluence_Pattern2_Should_Return_400()
    {
        //Arrange
        string[] pattern = [
            "#...##..#",
            "#....#..#",
            "..##..###",
            "#####.##.",
            "#####.##.",
            "..##..###",
            "#....#..#"];
        //Act
        var result = PointOfIncidence.FindReflectionAndAddColumns(pattern);

        //Assert
        result.Should().Be(400);
    }

    [Fact]
    public void PointOfInfluence_EdgeCase_Should_Return_1()
    {
        //Arrange
        string[] pattern = [
            "###.##.##",
            "##.####.#",
            "##.#..#.#",
            "####..###",
            "....##...",
            "##.#..#.#",
            "...#..#..",
            "##..###.#",
            "##......#",
            "##......#",
            "..#.##.#.",
            "...#..#..",
            "##.####.#",
            "....##...",
            "...####..",
            "....##...",
            "##.####.#"];

        //Act
        var result = PointOfIncidence.FindReflectionAndAddColumns(pattern);

        //Assert
        result.Should().Be(1);
    }

    [Fact]
    public void PointOfInfluence_EdgeCase2_Should_Return_2()
    {
        //Arrange
        string[] pattern = [
            ".##.##...##...##.",
            "#####..##..##..##",
            ".....##..##..##..",
            ".##.#.#.####.#.#.",
            ".##...#.#..#.#...",
            "....#..........#.",
            "#..#..#......#..#",
            "....###.....####.",
            ".##...#.#..#.#...",
            ".....#..####..#..",
            "#..#...##..##...#",
            "....#...#..#...#.",
            "#..#.##########.#",
            "#..##...####...##",
            "#####.##.##.##.##"];

        //Act
        var result = PointOfIncidence.FindReflectionAndAddColumns(pattern);

        //Assert
        result.Should().Be(2);
    }
}
