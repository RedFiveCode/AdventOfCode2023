using AdventOfCode2023;
using Day3;

//
// Part one
//
var reader = new EngineReader();

var engine = reader.Read(@".\PuzzleData.txt");

var sum = engine.GetPartNumberSum(); // 514969

Console.WriteLine(sum);


//
// Part two
//
var symbolReader = new SymbolReader();
var symbols = symbolReader.Read(@".\PuzzleData.txt");

var processor = new SymbolProcessor();

var gears = processor.GetGears(symbols);

gears.OrderBy(g => g.Row).ThenBy(g => g.First).ToList().ForEach(g => Console.WriteLine(g));

var gearSum = gears.Sum(g => g.GearRatio);

Console.WriteLine($"Gears: {gears.Count}, Sum: {gearSum}"); // 78915902


