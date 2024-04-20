namespace Day2.Test
{
    public class GameTest
    {
        [Fact]
        public void GetFewestCubeCounts_Game1_ReturnsMinimumCount()
        {
            var target = new GameReader();

            var games = target.Read(@".\ExampleData.txt");

            var result = games[0].GetFewestCubeCounts();

            Assert.NotNull(result);
            Assert.Equal(4, result.Red);
            Assert.Equal(2, result.Green);
            Assert.Equal(6, result.Blue);
        }

        [Theory]
        [InlineData(1, 4, 2, 6)]
        [InlineData(2, 1, 3, 4)]
        [InlineData(3, 20, 13, 6)]
        [InlineData(4, 14, 3, 15)]
        [InlineData(5, 6, 3, 2)]
        public void GetFewestCubeCounts_Games_ReturnsMinimumCount(int gameId, int expectedRed, int expectedGreen, int expectedBlue)
        {
            var target = new GameReader();

            var games = target.Read(@".\ExampleData.txt");

            var result = games.Where(g => g.Id == gameId).First().GetFewestCubeCounts();

            Assert.NotNull(result);
            Assert.Equal(expectedRed, result.Red);
            Assert.Equal(expectedGreen, result.Green);
            Assert.Equal(expectedBlue, result.Blue);
        }

        [Theory]
        [InlineData(1, 48)]
        [InlineData(2, 12)]
        [InlineData(3, 1560)]
        [InlineData(4, 630)]
        [InlineData(5, 36)]
        public void GetPowerSum_Games_ReturnsExpectedPower(int gameId, int expectedPower)
        {
            var target = new GameReader();

            var games = target.Read(@".\ExampleData.txt");

            var result = games.Where(g => g.Id == gameId).First().GetPowerSum();

            Assert.Equal(expectedPower, result);
        }
    }
}