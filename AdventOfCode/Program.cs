using AdventOfCode._2023.Day1;
using AdventOfCode._2023.Day2;
using AdventOfCode._2023.Day3;
using AdventOfCode._2023.Day4;
using AdventOfCode._2023.Day5;

Console.WriteLine("Advent of Code - Day 1");
Console.WriteLine("Part 1 sum of calibration values : " + DocumentExtractor.GetSumOfCalibrationValues("2023/Day1/input.txt", DocumentExtractor.patternPart1));
Console.WriteLine("Part 2 sum of calibration values : " + DocumentExtractor.GetSumOfCalibrationValues("2023/Day1/input.txt", DocumentExtractor.patternPart2));

Console.WriteLine("Advent of Code - Day 2");
Console.WriteLine("Part 1 sum of game ids : " + CubeGameSolver.SolvePart1CubeGame("2023/Day2/input.txt"));
Console.WriteLine("Part 2 sum of minimum cubes power : " + CubeGameSolver.SolvePart2CubeGame("2023/Day2/input.txt"));

Console.WriteLine("Advent of Code - Day 3");
Console.WriteLine("Part 1 sum of engine parts : " + EngineChecker.SolveEngineGamePart1("2023/Day3/input.txt"));
Console.WriteLine("Part 2 sum of valid gears : " + EngineChecker.SolveEngineGamePart2("2023/Day3/input.txt"));

Console.WriteLine("Advent of Code - Day 4");
Console.WriteLine("Part 1 sum of scratchcards points : " + ScratchcardAnalyzer.SolveScratchcardsPart1("2023/Day4/input.txt"));
Console.WriteLine("Part 2 sum of scratchcards copies : " + ScratchcardAnalyzer.SolveScratchcardsPart2("2023/Day4/input.txt"));

Console.WriteLine("Advent of Code - Day 5");
Console.WriteLine("Part 1 lowest seed location : " + SeedLocationFinder.SolveSeedLocationPart1("2023/Day5/input.txt"));
