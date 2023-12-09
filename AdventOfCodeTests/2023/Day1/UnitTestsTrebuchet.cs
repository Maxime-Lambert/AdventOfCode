using AdventOfCode._2023.Day1;

namespace AdventOfCodeTests._2023.Day1;

public class UnitTestsTrebuchet
{

    private const string PATTERN_DIGIT = @"\d";
    private const string PATTERN_DIGIT_OR_DIGIT_AS_TEST = @"\d|one|two|three|four|five|six|seven|eight|nine";

    [Fact]
    public void Calibration_Part1_Line1_Should_Return_12()
    {
        //Arrange
        const string calibrationDocumentLine = "1abc2";

        //Act
        var result = Trebuchet.GetCalibrationValue(calibrationDocumentLine, PATTERN_DIGIT);

        //Assert
        result.Should().Be(12);
    }

    [Fact]
    public void Calibration_Part1_Line2_Should_Return_38()
    {
        //Arrange
        const string calibrationDocumentLine = "pqr3stu8vwx";

        //Act
        var result = Trebuchet.GetCalibrationValue(calibrationDocumentLine, PATTERN_DIGIT);

        //Assert
        result.Should().Be(38);
    }

    [Fact]
    public void Calibration_Part1_Line3_Should_Return_15()
    {
        //Arrange
        const string calibrationDocumentLine = "a1b2c3d4e5f";

        //Act
        var result = Trebuchet.GetCalibrationValue(calibrationDocumentLine, PATTERN_DIGIT);

        //Assert
        result.Should().Be(15);
    }

    [Fact]
    public void Calibration_Part1_Line4_Should_Return_77()
    {
        //Arrange
        const string calibrationDocumentLine = "treb7uchet";

        //Act
        var result = Trebuchet.GetCalibrationValue(calibrationDocumentLine, PATTERN_DIGIT);

        //Assert
        result.Should().Be(77);
    }

    [Fact]
    public void Calibration_Part2_Line1_Should_Return_29()
    {
        //Arrange
        const string calibrationDocumentLine = "two1nine";

        //Act
        var result = Trebuchet.GetCalibrationValue(calibrationDocumentLine, PATTERN_DIGIT_OR_DIGIT_AS_TEST);

        //Assert
        result.Should().Be(29);
    }

    [Fact]
    public void Calibration_Part2_Line2_Should_Return_83()
    {
        //Arrange
        const string calibrationDocumentLine = "eightwothree";

        //Act
        var result = Trebuchet.GetCalibrationValue(calibrationDocumentLine, PATTERN_DIGIT_OR_DIGIT_AS_TEST);

        //Assert
        result.Should().Be(83);
    }

    [Fact]
    public void Calibration_Part2_Line3_Should_Return_13()
    {
        //Arrange
        const string calibrationDocumentLine = "abcone2threexyz";

        //Act
        var result = Trebuchet.GetCalibrationValue(calibrationDocumentLine, PATTERN_DIGIT_OR_DIGIT_AS_TEST);

        //Assert
        result.Should().Be(13);
    }

    [Fact]
    public void Calibration_Part2_Line4_Should_Return_24()
    {
        //Arrange
        const string calibrationDocumentLine = "xtwone3four";

        //Act
        var result = Trebuchet.GetCalibrationValue(calibrationDocumentLine, PATTERN_DIGIT_OR_DIGIT_AS_TEST);

        //Assert
        result.Should().Be(24);
    }

    [Fact]
    public void Calibration_Part2_Line5_Should_Return_42()
    {
        //Arrange
        const string calibrationDocumentLine = "4nineeightseven2";

        //Act
        var result = Trebuchet.GetCalibrationValue(calibrationDocumentLine, PATTERN_DIGIT_OR_DIGIT_AS_TEST);

        //Assert
        result.Should().Be(42);
    }

    [Fact]
    public void Calibration_Part2_Line6_Should_Return_14()
    {
        //Arrange
        const string calibrationDocumentLine = "zoneight234";

        //Act
        var result = Trebuchet.GetCalibrationValue(calibrationDocumentLine, PATTERN_DIGIT_OR_DIGIT_AS_TEST);

        //Assert
        result.Should().Be(14);
    }

    [Fact]
    public void Calibration_Part2_Line7_Should_Return_76()
    {
        //Arrange
        const string calibrationDocumentLine = "7pqrstsixteen";

        //Act
        var result = Trebuchet.GetCalibrationValue(calibrationDocumentLine, PATTERN_DIGIT_OR_DIGIT_AS_TEST);

        //Assert
        result.Should().Be(76);
    }

    [Fact]
    public void Calibration_Part2_OneWordAsDigit_Should_Return_22()
    {
        //Arrange
        const string calibrationDocumentLine = "two";

        //Act
        var result = Trebuchet.GetCalibrationValue(calibrationDocumentLine, PATTERN_DIGIT_OR_DIGIT_AS_TEST);

        //Assert
        result.Should().Be(22);
    }

    [Fact]
    public void Calibration_Part2_TwoDigitWordsMixedUp_Should_Return_82()
    {
        //Arrange
        const string calibrationDocumentLine = "eightwo";

        //Act
        var result = Trebuchet.GetCalibrationValue(calibrationDocumentLine, PATTERN_DIGIT_OR_DIGIT_AS_TEST);

        //Assert
        result.Should().Be(82);
    }
}
