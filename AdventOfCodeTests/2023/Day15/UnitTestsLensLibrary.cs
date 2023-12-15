using AdventOfCode.ProblemSolvers._2023.Day15;

namespace AdventOfCodeTests._2023.Day15;

public class UnitTestsLensLibrary
{
    [Fact]
    public void LensLibrary_Step1_Should_Return_30()
    {
        //Arrange
        const string step = "rn=1";

        //Act
        var result = LensLibrary.GetHash(step);

        //Assert
        result.Should().Be(30);
    }
    
    [Fact]
    public void LensLibrary_Step2_Should_Return_253()
    {
        //Arrange
        const string step = "cm-";

        //Act
        var result = LensLibrary.GetHash(step);

        //Assert
        result.Should().Be(253);
    }
    
    [Fact]
    public void LensLibrary_Step3_Should_Return_97()
    {
        //Arrange
        const string step = "qp=3";

        //Act
        var result = LensLibrary.GetHash(step);

        //Assert
        result.Should().Be(97);
    }
    
    [Fact]
    public void LensLibrary_Step4_Should_Return_47()
    {
        //Arrange
        const string step = "cm=2";

        //Act
        var result = LensLibrary.GetHash(step);

        //Assert
        result.Should().Be(47);
    }
    
    [Fact]
    public void LensLibrary_Step5_Should_Return_14()
    {
        //Arrange
        const string step = "qp-";

        //Act
        var result = LensLibrary.GetHash(step);

        //Assert
        result.Should().Be(14);
    }
    
    [Fact]
    public void LensLibrary_Step6_Should_Return_180()
    {
        //Arrange
        const string step = "pc=4";

        //Act
        var result = LensLibrary.GetHash(step);

        //Assert
        result.Should().Be(180);
    }
    
    [Fact]
    public void LensLibrary_Step7_Should_Return_9()
    {
        //Arrange
        const string step = "ot=9";

        //Act
        var result = LensLibrary.GetHash(step);

        //Assert
        result.Should().Be(9);
    }
    
    [Fact]
    public void LensLibrary_Step8_Should_Return_197()
    {
        //Arrange
        const string step = "ab=5";

        //Act
        var result = LensLibrary.GetHash(step);

        //Assert
        result.Should().Be(197);
    }

    [Fact]
    public void LensLibrary_Step9_Should_Return_48()
    {
        //Arrange
        const string step = "pc-";

        //Act
        var result = LensLibrary.GetHash(step);

        //Assert
        result.Should().Be(48);
    }

    [Fact]
    public void LensLibrary_Step10_Should_Return_214()
    {
        //Arrange
        const string step = "pc=6";

        //Act
        var result = LensLibrary.GetHash(step);

        //Assert
        result.Should().Be(214);
    }

    [Fact]
    public void LensLibrary_Step11_Should_Return_231()
    {
        //Arrange
        const string step = "ot=7";

        //Act
        var result = LensLibrary.GetHash(step);

        //Assert
        result.Should().Be(231);
    }

}
