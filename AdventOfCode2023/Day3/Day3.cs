using Day3;

var reader = new EngineReader();

var engine = reader.Read(@".\PuzzleData.txt");

var sum = engine.GetPartNumberSum(); // 514969

Console.WriteLine(sum);

