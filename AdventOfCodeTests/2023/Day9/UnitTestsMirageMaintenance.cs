using AdventOfCode.ProblemSolvers._2023.Day9;

namespace AdventOfCodeTests._2023.Day9;

public class UnitTestsMirageMaintenance
{
    [Fact]
    public void MirageMaintenance_History1_Should_Return_18()
    {
        //Arrange
        const string history = "0   3   6   9  12  15";

        //Act
        var result = MirageMaintenance.GetExtrapolatedValue(history);

        //Assert
        result.Should().Be(18);
    }

    [Fact]
    public void MirageMaintenance_History2_Should_Return_28()
    {
        //Arrange
        const string history = "1   3   6  10  15  21";

        //Act
        var result = MirageMaintenance.GetExtrapolatedValue(history);

        //Assert
        result.Should().Be(28);
    }

    [Fact]
    public void MirageMaintenance_History3_Should_Return_68()
    {
        //Arrange
        const string history = "10  13  16  21  30  45";

        //Act
        var result = MirageMaintenance.GetExtrapolatedValue(history);

        //Assert
        result.Should().Be(68);
    }
}
