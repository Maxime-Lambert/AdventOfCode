using AdventOfCode.InputReader;

namespace AdventOfCode.ProblemSolvers._2023.Day15;

public sealed class LensLibrary(IReadInputs inputReader) : ProblemSolver(inputReader)
{
    private const string INPUT_FILE_NAME = "InputDay15.txt";

    public override long SolvePart1()
    {
        return _inputReader.GetProblemInput(INPUT_FILE_NAME)[0].Split(',').Sum(GetHash);
    }

    public override long SolvePart2()
    {
        return 0;
    }

    public static int GetHash(string step)
    {
        var hash = 0;
        foreach (var character in step)
        {
            hash += character;
            hash *= 17;
            hash %= 256;
        }
        return hash;
    }
}
