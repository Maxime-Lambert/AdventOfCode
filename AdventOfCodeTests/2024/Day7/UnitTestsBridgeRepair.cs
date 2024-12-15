using AdventOfCode.ProblemSolvers._2024.Day7;

namespace AdventOfCodeTests._2024.Day7;
public class UnitTestsBridgeRepair
{
    [Fact]
    public void BridgeRepair_Part1_Should_Return190()
    {
        //Arrange
        string equation = "190: 10 19";

        //Act
        var result = BridgeRepair.IsEquationTrue(equation);

        //Assert
        result.Should().Be(190);
    }
    [Fact]
    public void BridgeRepair_Part1_Should_Return3267()
    {
        //Arrange
        string equation = "3267: 81 40 27";

        //Act
        var result = BridgeRepair.IsEquationTrue(equation);

        //Assert
        result.Should().Be(3267);
    }
    [Fact]
    public void BridgeRepair_Part1_Should_Return292()
    {
        //Arrange
        string equation = "292: 11 6 16 20";

        //Act
        var result = BridgeRepair.IsEquationTrue(equation);

        //Assert
        result.Should().Be(292);
    }
}
