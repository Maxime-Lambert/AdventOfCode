using AdventOfCode.InputReader;

namespace AdventOfCode.ProblemSolvers._2024.Day4;

public sealed class CeresSearch(IReadInputs inputReader) : ProblemSolver(inputReader)
{
    private const string INPUT_FILE_NAME = "2024/InputDay4.txt";

    public override long SolvePart1()
    {
        return XmasWordSearch(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public override long SolvePart2()
    {
        return CrossMasWordSearch(_inputReader.GetProblemInput(INPUT_FILE_NAME));
    }

    public static long XmasWordSearch(string[] grid)
    {
        var result = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for(int j = 0;  j < grid[i].Length; j++)
            {
                if(grid[i][j] == 'X')
                {
                    // en haut
                    if(i - 3 >= 0)
                    {
                        if (grid[i - 1][j] == 'M' && grid[i - 2][j] == 'A' && grid[i - 3][j] == 'S')
                        {
                            result++;
                        }
                        //en haut à droite
                        if (j + 3 < grid[i].Length)
                        {
                            if (grid[i - 1][j + 1] == 'M' && grid[i - 2][j + 2] == 'A' && grid[i - 3][j + 3] == 'S')
                            {
                                result++;
                            }
                        }
                        // en haut à gauche
                        if (j - 3 >= 0)
                        {
                            if (grid[i - 1][j - 1] == 'M' && grid[i - 2][j - 2] == 'A' && grid[i - 3][j - 3] == 'S')
                            {
                                result++;
                            }
                        }
                    }
                    //en bas
                    if(i + 3 < grid.Length)
                    {
                        if (grid[i + 1][j] == 'M' && grid[i + 2][j] == 'A' && grid[i + 3][j] == 'S')
                        {
                            result++;
                        }
                        // en bas à droite
                        if (j + 3 < grid[i].Length)
                        {
                            if (grid[i + 1][j + 1] == 'M' && grid[i + 2][j + 2] == 'A' && grid[i + 3][j + 3] == 'S')
                            {
                                result++;
                            }
                        }
                        //en bas à gauche
                        if (j - 3 >= 0)
                        {
                            if (grid[i + 1][j - 1] == 'M' && grid[i + 2][j - 2] == 'A' && grid[i + 3][j - 3] == 'S')
                            {
                                result++;
                            }
                        }
                    }
                    // à droite
                    if (j + 3 < grid[i].Length)
                    {
                        if (grid[i][j + 1] == 'M' && grid[i][j + 2] == 'A' && grid[i][j + 3] == 'S')
                        {
                            result++;
                        }
                    }
                    // à gauche
                    if (j - 3 >= 0)
                    {
                        if (grid[i][j - 1] == 'M' && grid[i][j - 2] == 'A' && grid[i][j - 3] == 'S')
                        {
                            result++;
                        }
                    }
                }
            }
        }
        return result;
    }

    public static long CrossMasWordSearch(string[] grid)
    {
        var result = 0;
        for (int i = 1; i < grid.Length - 1; i++)
        {
            for (int j = 1; j < grid[i].Length - 1; j++)
            {
                if (grid[i][j] == 'A')
                {
                    var topLeftLetter = grid[i - 1][j - 1];
                    var topRightLetter = grid[i - 1][j + 1];
                    var bottomLeftLetter = grid[i + 1][j - 1];
                    var bottomRightLetter = grid[i + 1][j + 1];

                    if ( (topLeftLetter == 'M' || topLeftLetter == 'S') && 
                         (bottomRightLetter == 'M' || bottomRightLetter == 'S') && 
                         topLeftLetter != bottomRightLetter &&
                         (bottomLeftLetter == 'M' || bottomLeftLetter == 'S') &&
                         (topRightLetter == 'M' || topRightLetter == 'S') &&
                         bottomLeftLetter != topRightLetter)
                    {
                        result++;
                    }
                }
            }
        }
        return result;
    }
}
