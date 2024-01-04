namespace Day3.Test
{
    public class SymbolReaderTest
    {
        [Fact]
        public void Read_PartTwo_Returns_EngineWithExpectedListOfGears()
        {
            var target = new SymbolReader();

            var symbols = target.Read(@".\ExampleData.txt");

            var processor = new SymbolProcessor();
            var gears = processor.GetGears(symbols);

            Assert.NotNull(gears);

            Assert.Equal(2, gears.Count);

            AssertGear(gears[0], 467, 35);
            AssertGear(gears[1], 755, 598);

            //Assert.Equal(467835, result.GetGearRatioSum());
        }

        private void AssertGear(Gear gear, int expectedFirst, int expectedSecond)
        {
            Assert.NotNull(gear);
            Assert.Equal(expectedFirst, gear.First);
            Assert.Equal(expectedSecond, gear.Second);
            Assert.Equal(expectedFirst * expectedSecond, gear.GearRatio);
        }
    }
}