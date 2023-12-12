using AdventOfCode._2023.Day1;
using AdventOfCode._2023.Day2;
using AdventOfCode._2023.Day3;
using AdventOfCode._2023.Day4;
using AdventOfCode._2023.Day5;
using AdventOfCode._2023.Day6;
using AdventOfCode._2023.Day7;
using AdventOfCode.InputReader;
using AdventOfCode.ProblemSolvers._2023.Day10;
using AdventOfCode.ProblemSolvers._2023.Day8;
using AdventOfCode.ProblemSolvers._2023.Day9;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IReadInputs, FileReader>()
    .BuildServiceProvider();

var inputReader = serviceProvider.GetService<IReadInputs>();

var trebuchet = new Trebuchet(inputReader);
Console.WriteLine("Advent of Code - Day 1");
Console.WriteLine("Part 1 sum of calibration values : " + trebuchet.SolvePart1());
Console.WriteLine("Part 2 sum of calibration values : " + trebuchet.SolvePart2());
Console.WriteLine("");

var cubeConundrum = new CubeConundrum(inputReader);
Console.WriteLine("Advent of Code - Day 2");
Console.WriteLine("Part 1 sum of game ids : " + cubeConundrum.SolvePart1());
Console.WriteLine("Part 2 sum of minimum cubes power : " + cubeConundrum.SolvePart2());
Console.WriteLine("");

var gearRatios = new GearRatios(inputReader);
Console.WriteLine("Advent of Code - Day 3");
Console.WriteLine("Part 1 sum of engine parts : " + gearRatios.SolvePart1());
Console.WriteLine("Part 2 sum of valid gears : " + gearRatios.SolvePart2());
Console.WriteLine("");

var scratchCards = new Scratchcards(inputReader);
Console.WriteLine("Advent of Code - Day 4");
Console.WriteLine("Part 1 sum of scratchcards points : " + scratchCards.SolvePart1());
Console.WriteLine("Part 2 sum of scratchcards copies : " + scratchCards.SolvePart2());
Console.WriteLine("");

var ifYouGiveASeedAFertilizer = new IfYouGiveASeedAFertilizer(inputReader);
Console.WriteLine("Advent of Code - Day 5");
Console.WriteLine("Part 1 lowest seed location : " + ifYouGiveASeedAFertilizer.SolvePart1());
Console.WriteLine("Part 2 lowest seed location : " + ifYouGiveASeedAFertilizer.SolvePart2());
Console.WriteLine("");

var waitForIt = new WaitForIt(inputReader);
Console.WriteLine("Advent of Code - Day 6");
Console.WriteLine("Part 1 product of numbers of winning ways : " + waitForIt.SolvePart1());
Console.WriteLine("Part 2 number of winning ways : " + waitForIt.SolvePart2());
Console.WriteLine("");

var camelCards = new CamelCards(inputReader);
Console.WriteLine("Advent of Code - Day 7");
Console.WriteLine("Part 1 sum of winnings : " + camelCards.SolvePart1());
Console.WriteLine("Part 2 sum of winnings : " + camelCards.SolvePart2());
Console.WriteLine("");

var hauntedWasteland = new HauntedWasteland(inputReader);
Console.WriteLine("Advent of Code - Day 8");
Console.WriteLine("Part 1 steps to reach ZZZ : " + hauntedWasteland.SolvePart1());
Console.WriteLine("Part 2 steps to reach Zs simultaneously : " + hauntedWasteland.SolvePart2());
Console.WriteLine("");

var mirageMaintenance = new MirageMaintenance(inputReader);
Console.WriteLine("Advent of Code - Day 9");
Console.WriteLine("Part 1 sum of extrapolated values : " + mirageMaintenance.SolvePart1());
Console.WriteLine("Part 2 sum of extrapolated values : " + mirageMaintenance.SolvePart2());
Console.WriteLine("");

var pipeMaze = new PipeMaze(inputReader);
Console.WriteLine("Advent of Code - Day 10");
Console.WriteLine("Part 1 furthest distance in loop : " + pipeMaze.SolvePart1());
Console.WriteLine("Part 2 furthest distance in loop : " + pipeMaze.SolvePart2());
Console.WriteLine("");
