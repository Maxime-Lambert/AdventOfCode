using AdventOfCode.ProblemSolvers._2023.Day8;

namespace AdventOfCodeTests._2023.Day8;

public class UnitTestsHauntedWasteland
{
    [Fact]
    public void HauntedWasteland_Network1_Should_Return_2()
    {
        //Arrange
        string[] network = ["RL",
            "",
            "AAA = (BBB, CCC)",
            "BBB = (DDD, EEE)",
            "CCC = (ZZZ, GGG)",
            "DDD = (DDD, DDD)",
            "EEE = (EEE, EEE)",
            "GGG = (GGG, GGG)",
            "ZZZ = (ZZZ, ZZZ)"];

        //Act
        var result = HauntedWasteland.CalculateStepsToReachZZZ(network);

        //Assert
        result.Should().Be(2);
    }

    [Fact]
    public void HauntedWasteland_Network2_Should_Return_6()
    {
        //Arrange
        string[] network = ["LLR",
            "",
            "AAA = (BBB, BBB)",
            "BBB = (AAA, ZZZ)",
            "ZZZ = (ZZZ, ZZZ)"];

        //Act
        var result = HauntedWasteland.CalculateStepsToReachZZZ(network);

        //Assert
        result.Should().Be(6);
    }

    [Fact]
    public void HauntedWasteland_Part2_Should_Return_6()
    {
        //Arrange
        string[] network = ["LR",
            "",
            "11A = (11B, XXX)",
            "11B = (XXX, 11Z)",
            "11Z = (11B, XXX)",
            "22A = (22B, XXX)",
            "22B = (22C, 22C)",
            "22C = (22Z, 22Z)",
            "22Z = (22B, 22B)",
            "XXX = (XXX, XXX)"];

        //Act
        var result = HauntedWasteland.CalculateStepsToReachZSimultaneously(network);

        //Assert
        result.Should().Be(6);
    }
}
