using AdventOfCode.InputReader;

namespace AdventOfCode.ProblemSolvers._2024.Day2;
public sealed class RedNosedReports(IReadInputs inputReader) : ProblemSolver(inputReader)
{
    private const string INPUT_FILE_NAME = "2024/InputDay2.txt";

    public override long SolvePart1()
    {
        return _inputReader.GetProblemInput(INPUT_FILE_NAME).Where(IsReportSafe).Count();
    }

    public override long SolvePart2()
    {
        return _inputReader.GetProblemInput(INPUT_FILE_NAME).Where(IsReportSafeWithProblemDampener).Count();
    }

    public static bool IsReportSafe(string report) {
        var levels = report.Split(' ');
        var firstDifference = int.Parse(levels[0]) - int.Parse(levels[1]);
        if (firstDifference == 0 || Math.Abs(firstDifference) > 3) {
            return false;
        }
        bool increasing = firstDifference < 0;
        for (int i = 1; i < levels.Length - 1; i++)
        {
            var difference = int.Parse(levels[i]) - int.Parse(levels[i+1]);
            if (increasing)
            {
                if (difference > -1 || difference < -3)
                {
                    return false;
                }
            } else
            {
                if (difference < 1 || difference > 3)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool IsReportSafeWithProblemDampener(string report)
    {
        var levels = report.Split(' ');
        var firstDifference = int.Parse(levels[0]) - int.Parse(levels[1]);
        var problemDampener = false;
        if (firstDifference == 0 || Math.Abs(firstDifference) > 3)
        {
            problemDampener = true;
        }
        bool increasing = firstDifference < 0;
        for (int i = 1; i < levels.Length - 1; i++)
        {
            var difference = int.Parse(levels[i]) - int.Parse(levels[i + 1]);
            if (increasing)
            {
                if (difference > -1 || difference < -3)
                {
                    if(problemDampener)
                    {
                        return false;
                    } else
                    {
                        problemDampener = true;
                    }
                }
            }
            else
            {
                if (difference < 1 || difference > 3)
                {
                    if (problemDampener)
                    {
                        return false;
                    }
                    else
                    {
                        problemDampener = true;
                    }
                }
            }
        }
        return true;
    }
}
