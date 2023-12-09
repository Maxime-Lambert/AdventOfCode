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
}
