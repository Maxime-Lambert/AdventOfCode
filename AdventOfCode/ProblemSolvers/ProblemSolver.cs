using AdventOfCode.InputReader;

namespace AdventOfCode.ProblemSolvers;

public abstract class ProblemSolver(IReadInputs inputReader)
{
    protected readonly IReadInputs _inputReader = inputReader;

    public abstract long SolvePart1();

    public abstract long SolvePart2();
}
