// See https://aka.ms/new-console-template for more information
using Day1;

Console.WriteLine("Part One");

var target = new CalibrationReader();

var result = target.GetCalibrationSum(@".\PuzzleData.txt");

Console.WriteLine($"Result: {result}"); // 54605



Console.WriteLine("Part Two");

var targetTwo = new CalibrationReaderPartTwo();

var resultTwo = targetTwo.GetCalibrationSum(@".\PuzzleData.txt");

Console.WriteLine($"Result: {resultTwo}"); // 55429

