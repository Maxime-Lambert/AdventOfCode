using AdventOfCode.ProblemSolvers._2023.Day12;

namespace AdventOfCodeTests._2023.Day12;

public class UnitTestsHotSprings
{
    [Fact]
    public void HotSprings_Record1_Should_Return_1()
    {
        //Arrange
        const string record = "???.### 1,1,3";

        //Act
        var result = HotSprings.GetPossibleArrangements(record);

        //Assert
        result.Should().Be(1);
    }

    [Fact]
    public void HotSprings_Record2_Should_Return_4()
    {
        //Arrange
        const string record = ".??..??...?##. 1,1,3";

        //Act
        var result = HotSprings.GetPossibleArrangements(record);

        //Assert
        result.Should().Be(4);
    }

    [Fact]
    public void HotSprings_Record3_Should_Return_1()
    {
        //Arrange
        const string record = "?#?#?#?#?#?#?#? 1,3,1,6";

        //Act
        var result = HotSprings.GetPossibleArrangements(record);

        //Assert
        result.Should().Be(1);
    }

    [Fact]
    public void HotSprings_Record4_Should_Return_1()
    {
        //Arrange
        const string record = "????.#...#... 4,1,1";

        //Act
        var result = HotSprings.GetPossibleArrangements(record);

        //Assert
        result.Should().Be(1);
    }

    [Fact]
    public void HotSprings_Record5_Should_Return_4()
    {
        //Arrange
        const string record = "????.######..#####. 1,6,5";

        //Act
        var result = HotSprings.GetPossibleArrangements(record);

        //Assert
        result.Should().Be(4);
    }

    [Fact]
    public void HotSprings_Record6_Should_Return_10()
    {
        //Arrange
        const string record = "?###???????? 3,2,1";

        //Act
        var result = HotSprings.GetPossibleArrangements(record);

        //Assert
        result.Should().Be(10);
    }
}
