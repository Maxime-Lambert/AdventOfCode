namespace AdventOfCode.InputReader;

public class FileReader : IReadInputs
{
    private const string PATH_TO_RESOURCES = "Resources/";

    public string[] GetProblemInput(string fileName)
    {
        return File.ReadAllLines(Path.Combine(PATH_TO_RESOURCES, fileName));
    }
}
