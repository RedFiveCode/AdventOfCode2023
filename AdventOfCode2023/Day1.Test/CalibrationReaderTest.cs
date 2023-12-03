using System.Xml.Serialization;
using Xunit;

namespace Day1.Test
{
    public class CalibrationReaderTest
    {
        [Fact]
        public void ReadCalibration_ExampleData_ReturnsExpectedData()
        {
            // arrange
            var target = new CalibrationReader();

            // act
            var result = target.ReadCalibration(@".\ExampleData.txt");

            // assert
            var expected = new List<int> { 12, 38, 15, 77 };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetCalibrationSum_ExampleData_ReturnsExpectedData()
        {
            // arrange
            var target = new CalibrationReader();

            // act
            var result = target.GetCalibrationSum(@".\ExampleData.txt");

            // assert
            var expected = 142;

            Assert.Equal(expected, result);
        }
    }
}