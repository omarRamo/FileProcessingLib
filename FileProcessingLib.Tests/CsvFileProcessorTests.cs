using FileProcessingLib.Infrastructure.Processors;
using Bogus;

namespace FileProcessingLib.Tests
{
    public class CsvFileProcessorTests
    {
        [Fact]
        public void Process_ValidCsvInput_ReturnsExpectedOutput()
        {
            // Arrange
            var faker = new Faker();
            var fakeData = new List<string>
            {
                "Ref;Date;Amount;Rate" // CSV Header
            };

            // Generate 10 rows of fake data
            for (int i = 0; i < 10; i++)
            {
                var row = $"{faker.Random.AlphaNumeric(4)};" +
                          $"{faker.Date.Past(3).ToString("yyyy-MM-dd")};" +
                          $"{faker.Random.Decimal(0, 1000):F2};" +
                          $"{faker.Random.Decimal(0.001m, 0.01m):F3}";
                fakeData.Add(row);
            }

            var csvProcessor = new CsvFileProcessor();

            // Act
            var result = csvProcessor.Process(fakeData);

            // Assert
            Assert.Equal(10, result.Count);
            foreach (var output in result)
            {
                Assert.False(string.IsNullOrEmpty(output.OriginalSourceId));
                Assert.True(decimal.TryParse(output.Value.ToString(), out _));
                Assert.True(decimal.TryParse(output.Rate.ToString(), out _));
            }
        }
    }
}
