namespace Day3.Test
{
    public class EngineReaderTest
    {
        [Fact]
        public void Read_Returns_ExpectedListOfParts()
        {
            var target = new EngineReader();

            var result = target.Read(@".\ExampleData.txt");

            Assert.NotNull(result);
            Assert.NotNull(result.Parts);
            Assert.NotEmpty(result.Parts);

            Assert.NotNull(result.PartNumbers);
            Assert.NotEmpty(result.PartNumbers);

            Assert.DoesNotContain(114, result.PartNumbers);
            Assert.DoesNotContain(58, result.PartNumbers);

            Assert.Equal(8, result.PartNumbers.Count);
            Assert.Contains(467, result.PartNumbers);
            Assert.Contains(35, result.PartNumbers);
            Assert.Contains(633, result.PartNumbers);
            Assert.Contains(617, result.PartNumbers);
            Assert.Contains(592, result.PartNumbers);
            Assert.Contains(755, result.PartNumbers);
            Assert.Contains(664, result.PartNumbers);
            Assert.Contains(598, result.PartNumbers);
        }

        [Fact]
        public void GetPartNumberSum_Returns_ExpectedSum()
        {
            var target = new EngineReader();

            var result = target.Read(@".\ExampleData.txt");

            Assert.NotNull(result);

            Assert.Equal(4361, result.GetPartNumberSum());
        }
    }
}