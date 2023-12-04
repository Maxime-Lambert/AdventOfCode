﻿using AdventOfCode._2023.Day1;
using AdventOfCode._2023.Day2;

Console.WriteLine("Advent of Code - Day 1");
Console.WriteLine("Part 1 sum of calibration values : " + DocumentExtractor.GetSumOfCalibrationValues("2023/Day1/input.txt", DocumentExtractor.patternPart1));
Console.WriteLine("Part 2 sum of calibration values : " + DocumentExtractor.GetSumOfCalibrationValues("2023/Day1/input.txt", DocumentExtractor.patternPart2));

Console.WriteLine("Advent of Code - Day 2");
Console.WriteLine("Part 1 sum of game ids : " + CubeGameSolver.SolveCubeGame("2023/Day2/input.txt"));
