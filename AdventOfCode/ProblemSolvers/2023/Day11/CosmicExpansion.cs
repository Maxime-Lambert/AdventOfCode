using System.Drawing;
using AdventOfCode.InputReader;

namespace AdventOfCode.ProblemSolvers._2023.Day11;

public sealed class CosmicExpansion(IReadInputs inputReader) : ProblemSolver(inputReader)
{
    private const string INPUT_FILE_NAME = "InputDay11.txt";

    public override long SolvePart1()
    {
        return GetSumOfShortestPathsBetweenGalaxies(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public override long SolvePart2()
    {
        return 0;
    }

    public static int GetSumOfShortestPathsBetweenGalaxies(string[] image)
    {
        var expandedSpace = ExpandSpace(image);
        var galaxyCoordinates = GetGalaxies(expandedSpace);
        var sumOfShortestPaths = 0;
        for (int i = 0; i < galaxyCoordinates.Count; i++)
        {
            sumOfShortestPaths += galaxyCoordinates.Skip(i).Select(galaxy => Math.Abs(galaxy.X - galaxyCoordinates[i].X) + Math.Abs(galaxy.Y - galaxyCoordinates[i].Y)).Sum();
        }
        return sumOfShortestPaths;
    }

    public static string[] ExpandSpace(string[] image)
    {
        var imageExpanded = image.ToList();
        ExpandHorizontallyImageExpanded(image, imageExpanded);
        ExpandVerticallyImageExpanded(image, imageExpanded);
        return [.. imageExpanded];
    }

    private static void ExpandVerticallyImageExpanded(string[] image, List<string> imageExpanded)
    {
        var numberOfExpansions = 0;
        for (int i = 0; i < image[0].Length; i++)
        {
            var needsToExpand = true;
            for (int j = 0; j < image.Length; j++)
            {
                needsToExpand &= (image[j][i] == '.');
            }
            if (needsToExpand)
            {
                numberOfExpansions++;
                AddPointColumn(imageExpanded, numberOfExpansions, i);
            }
        }
    }

    private static void AddPointColumn(List<string> imageExpanded, int numberOfExpansions, int i)
    {
        for (int x = 0; x < imageExpanded.Count; x++)
        {
            if (i + numberOfExpansions == imageExpanded[0].Length)
            {
                imageExpanded[x] += ".";
            }
            else
            {
                imageExpanded[x] = imageExpanded[x].Insert(i + numberOfExpansions, ".");
            }
        }
    }

    private static void ExpandHorizontallyImageExpanded(string[] image, List<string> imageExpanded)
    {
        var numberOfExpansions = 0;
        for (int i = 0; i < image.Length; i++)
        {
            if (!image[i].Contains('#'))
            {
                imageExpanded.Insert(i + ++numberOfExpansions, new string('.', image[0].Length));
            }
        }
    }

    public static List<Point> GetGalaxies(string[] image)
    {
        var galaxyCoordinates = new List<Point>();
        for(int j = 0; j < image.Length; j++)
        {
            for(int i = 0; i < image[j].Length; i++) 
            {
                if (image[j][i] == '#')
                {
                    galaxyCoordinates.Add(new Point(i, j));
                }
            }
        }
        return galaxyCoordinates;
    }
}
