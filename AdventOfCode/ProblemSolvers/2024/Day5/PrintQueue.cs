using AdventOfCode.InputReader;

namespace AdventOfCode.ProblemSolvers._2024.Day5;

public sealed class PrintQueue(IReadInputs inputReader) : ProblemSolver(inputReader)
{
    private const string INPUT_FILE_NAME = "2024/InputDay5.txt";

    public override long SolvePart1()
    {
        return AddMiddleNumbersWhenCorrect(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public override long SolvePart2()
    {
        return AddMiddleNumbersWhenUncorrect(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public static long AddMiddleNumbersWhenCorrect(string[] input)
    {
        Dictionary<int, IEnumerable<int>> pageOrderingRules = [];
        var result = 0;
        foreach (string line in input)
        {
            if (line.Length > 0)
            {
                if (line.Contains('|'))
                {
                    var splittedLine = line.Split('|');
                    var leftPage = int.Parse(splittedLine[0]);
                    var rightPage = int.Parse(splittedLine[1]);
                    if (!pageOrderingRules.TryAdd(leftPage, new List<int>() { rightPage }))
                    {
                        pageOrderingRules[leftPage] = pageOrderingRules[leftPage].Append(rightPage);
                    }
                }
                else
                {
                    var splittedLine = line.Split(',');
                    var isLineOk = true;
                    for (int i = 1; i < splittedLine.Length; i++)
                    {
                        var pageValue = int.Parse(splittedLine[i]);
                        if (pageOrderingRules.TryGetValue(pageValue, out var pageOrders))
                        {
                            if (splittedLine.Take(i).Select(int.Parse).Intersect(pageOrders).Any())
                            {
                                isLineOk = false;
                            };
                        }
                    }
                    if (isLineOk)
                    {
                        result += int.Parse(splittedLine[splittedLine.Length / 2]);
                    }
                }
            }
        }
        return result;
    }

    public static long AddMiddleNumbersWhenUncorrect(string[] input)
    {
        Dictionary<int, IList<int>> pageOrderingRules = [];
        var result = 0;
        foreach (string line in input)
        {
            if (line.Length > 0)
            {
                if (line.Contains('|'))
                {
                    var splittedLine = line.Split('|');
                    var leftPage = int.Parse(splittedLine[0]);
                    var rightPage = int.Parse(splittedLine[1]);
                    if (!pageOrderingRules.TryAdd(leftPage, new List<int>() { rightPage }))
                    {
                        pageOrderingRules[leftPage].Add(rightPage);
                    }
                }
                else
                {
                    var splittedLine = line.Split(',');
                    var isLineOk = true;
                    for (int i = 1; i < splittedLine.Length; i++)
                    {
                        var pageValue = int.Parse(splittedLine[i]);
                        if (pageOrderingRules.TryGetValue(pageValue, out var pageOrders))
                        {
                            if (splittedLine.Take(i).Select(int.Parse).Intersect(pageOrders).Any())
                            {
                                isLineOk = false;
                            };
                        }
                    }
                    if (!isLineOk)
                    {
                        List<int> orderedIncorrectUpdate = [.. splittedLine.Select(int.Parse)];
                        foreach (var page in splittedLine.Skip(1))
                        {
                            var pageAsNumber = int.Parse(page);
                            var index = 0;
                            var naokiLeMeilleur = splittedLine.ToList().IndexOf(page);
                            while (index < naokiLeMeilleur)
                            {
                                if(pageOrderingRules[pageAsNumber].ToList().Contains(orderedIncorrectUpdate.ElementAt(index)))
                                {
                                    orderedIncorrectUpdate.Remove(pageAsNumber);
                                    orderedIncorrectUpdate.Insert(index, pageAsNumber);
                                    break;
                                }
                                index++;
                            }
                        }
                        result += orderedIncorrectUpdate.ElementAt(orderedIncorrectUpdate.Count / 2);
                    }
                }
            }
        }
        return result;
    }
}
