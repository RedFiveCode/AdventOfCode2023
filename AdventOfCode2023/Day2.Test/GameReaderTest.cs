namespace Day2.Test
{
    public class GameReaderTest
    {
        [Fact]
        public void Read_ReturnsExpectedData()
        {
            var target = new GameReader();

            var results = target.Read(@".\ExampleData.txt");

            Assert.NotNull(results);
            Assert.Equal(5, results.Count());

            AssertGame(results[0], 1, 3);
            AssertGameContainsRound(results[0], 4, 0, 3);
            AssertGameContainsRound(results[0], 1, 2, 6);
            AssertGameContainsRound(results[0], 0, 2, 0);

            AssertGame(results[1], 2, 3);
            AssertGameContainsRound(results[1], 0, 2, 1);
            AssertGameContainsRound(results[1], 1, 3, 4);
            AssertGameContainsRound(results[1], 0, 1, 1);

            AssertGame(results[2], 3, 3);
            AssertGameContainsRound(results[2], 20, 8, 6);
            AssertGameContainsRound(results[2], 4, 13, 5);
            AssertGameContainsRound(results[2], 1, 5, 0);

            AssertGame(results[3], 4, 3);
            AssertGameContainsRound(results[3], 3, 1, 6);
            AssertGameContainsRound(results[3], 6, 3, 0);
            AssertGameContainsRound(results[3], 14, 3, 15);

            AssertGame(results[4], 5, 2);
            AssertGameContainsRound(results[4], 6, 3, 1);
            AssertGameContainsRound(results[4], 1, 2, 2);
        }

        [Fact]
        public void IsPossible_Red12_Green14_Blue14_Game1_ReturnsTrue()
        {
            var target = new GameReader();

            var games = target.Read(@".\ExampleData.txt");

            var result = games[0].IsPossible(12, 13, 14);

            Assert.True(result);
        }

        [Fact]
        public void IsPossible_Red12_Green14_Blue14_Game2_ReturnsTrue()
        {
            var target = new GameReader();

            var games = target.Read(@".\ExampleData.txt");

            var result = games[1].IsPossible(12, 13, 14);

            Assert.True(result);
        }

        [Fact]
        public void IsPossible_Red12_Green14_Blue14_Game3_ReturnsFalse()
        {
            var target = new GameReader();

            var games = target.Read(@".\ExampleData.txt");

            var result = games[2].IsPossible(12, 13, 14);

            Assert.False(result);
        }

        [Fact]
        public void IsPossible_Red12_Green14_Blue14_Game4_ReturnsFalse()
        {
            var target = new GameReader();

            var games = target.Read(@".\ExampleData.txt");

            var result = games[3].IsPossible(12, 13, 14);

            Assert.False(result);
        }

        [Fact]
        public void IsPossible_Red12_Green14_Blue14_Game5_ReturnsTrue()
        {
            var target = new GameReader();

            var games = target.Read(@".\ExampleData.txt");

            var result = games[4].IsPossible(12, 13, 14);

            Assert.True(result);
        }

        [Fact]
        public void IsPossible_Red12_Green14_Blue14()
        {
            var target = new GameReader();

            var games = target.Read(@".\ExampleData.txt");

            var possibleGames = games.Where(g => g.IsPossible(12, 13, 14)).ToList();

            var sumPossibleGames = possibleGames.Sum(g => g.Id);

            Assert.Equal(8, sumPossibleGames);
        }

        private void AssertGame(Game game, int expectedId, int expectedRounds)
        {
            Assert.Equal(expectedId, game.Id);
            Assert.Equal(expectedRounds, game.Rounds.Count);
        }

        private void AssertGameContainsRound(Game game, int expectedRed, int expectedGreen, int expectedBlue)
        {
            Assert.True(game.Rounds.Any(r => r.Red == expectedRed && r.Green == expectedGreen && r.Blue == expectedBlue));
        }
    }
}