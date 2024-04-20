namespace Day1.Test
{
    public class CalibrationReaderPartTwoTest
    {
        [Fact]
        public void ReadCalibration_ExampleData_ReturnsExpectedData()
        {
            // arrange
            var target = new CalibrationReaderPartTwo();

            // act
            var result = target.ReadCalibration(@".\ExampleData.PartTwo.txt");

            // assert
            var expected = new List<int> { 29, 83, 13, 24, 42, 14, 76 };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetCalibrationSum_ExampleData_ReturnsExpectedData()
        {
            // arrange
            var target = new CalibrationReaderPartTwo();

            // act
            var result = target.GetCalibrationSum(@".\ExampleData.PartTwo.txt");

            // assert
            var expected = 281;

            Assert.Equal(expected, result);
        }

        // https://www.reddit.com/r/adventofcode/comments/1884fpl/2023_day_1for_those_who_stuck_on_part_2/
        [Fact]
        public void ReadCalibration_SpecialCaseExampleData_ReturnsExpectedData()
        {
            // arrange
            var target = new CalibrationReaderPartTwo();

            // act
            var result = target.ReadCalibration(new string[] { "eighthree", "sevenine" });

            // assert
            var expected = new List<int> { 83, 79 }; // not 88, 77

            Assert.Equal(expected, result);

        }
    }
}
