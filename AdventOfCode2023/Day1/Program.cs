// See https://aka.ms/new-console-template for more information
using Day1;

Console.WriteLine("Hello, World!");

var target = new CalibrationReader();

var result = target.GetCalibrationSum(@".\PuzzleData.txt");

Console.WriteLine($"Result: {result}"); // 54605

