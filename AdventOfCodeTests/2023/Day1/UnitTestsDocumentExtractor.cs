using AdventOfCode._2023.Day1;

namespace AdventOfCodeTests._2023.Day1;

public class UnitTestsDocumentExtractor
{
    [Fact]
    public void Calibration_Should_Return_12()
    {
        //Arrange
        const string calibrationDocumentLine = "1abc2";

        //Act
        var result = DocumentExtractor.GetCalibrationValue(calibrationDocumentLine);

        //Assert
        _ = result.Should().Be(12);
    }

    [Fact]
    public void Calibration_Should_Return_38()
    {
        //Arrange
        const string calibrationDocumentLine = "pqr3stu8vwx";

        //Act
        var result = DocumentExtractor.GetCalibrationValue(calibrationDocumentLine);

        //Assert
        _ = result.Should().Be(38);
    }

    [Fact]
    public void Calibration_Should_Return_15()
    {
        //Arrange
        const string calibrationDocumentLine = "a1b2c3d4e5f";

        //Act
        var result = DocumentExtractor.GetCalibrationValue(calibrationDocumentLine);

        //Assert
        _ = result.Should().Be(15);
    }

    [Fact]
    public void Calibration_Should_Return_77()
    {
        //Arrange
        const string calibrationDocumentLine = "treb7uchet";

        //Act
        var result = DocumentExtractor.GetCalibrationValue(calibrationDocumentLine);

        //Assert
        _ = result.Should().Be(77);
    }
}
