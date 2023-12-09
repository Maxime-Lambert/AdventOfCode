namespace AdventOfCode._2023.Day2;

internal class CubeGame
{
    private int BlueMinimumValue { get; set; }
    private int RedMinimumValue { get; set; }
    private int GreenMinimumValue { get; set; }

    public CubeGame()
    {
        BlueMinimumValue = 0;
        RedMinimumValue = 0;
        GreenMinimumValue = 0;
    }

    public int GetProductOfColorValues()
    {
        return BlueMinimumValue * RedMinimumValue * GreenMinimumValue;
    }

    public void UpdateBlueMinimumValue(int blueValue)
    {
        if (BlueMinimumValue < blueValue)
        {
            BlueMinimumValue = blueValue;
        }
    }
    public void UpdateRedMinimumValue(int redValue)
    {
        if (RedMinimumValue < redValue)
        {
            RedMinimumValue = redValue;
        }
    }
    public void UpdateGreenMinimumValue(int greenValue)
    {
        if (GreenMinimumValue < greenValue)
        {
            GreenMinimumValue = greenValue;
        }
    }
}
