using Day2;

var reader = new GameReader();

var games = reader.Read(@".\PuzzleData.txt");

var possibleGames = games.Where(g => g.IsPossible(12, 13, 14)).ToList();

var sumPossibleGames = possibleGames.Sum(g => g.Id);

Console.WriteLine(sumPossibleGames); // 2101
