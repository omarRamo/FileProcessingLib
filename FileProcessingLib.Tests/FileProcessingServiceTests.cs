using FileProcessingLib.Application.Interfaces;
using FileProcessingLib.Application.Services;
using FileProcessingLib.Domain.Entities;
using Moq;

namespace FileProcessingLib.Tests
{
    public class FileProcessingServiceTests
    {
        [Fact]
        public void ProcessFile_ValidData_CallsSerializer()
        {
            // Arrange
            var mockSerializer = new Mock<IOutputSerializer>();
            var fakeData = new List<OutputData>
            {
                new OutputData
                {
                    OriginalSourceId = "A001",
                    TransactionDate = "2019-06-30",
                    Value = 123.45m,
                    Rate = 0.006m
                },
                new OutputData
                {
                    OriginalSourceId = "A002",
                    TransactionDate = "2019-07-01",
                    Value = 456.78m,
                    Rate = 0.003m
                }
            };

            mockSerializer
                .Setup(s => s.Serialize(It.IsAny<List<OutputData>>()))
                .Returns("[Mocked JSON Output]");

            var service = new FileProcessingService(mockSerializer.Object);

            // Act
            var result = service.ProcessFile(new List<string>
            {
                "Ref;Date;Amount;Rate",
                "A001;2019-06-30;123.45;0.006",
                "A002;2019-07-01;456.78;0.003"
            });

            // Assert
            Assert.Equal("[Mocked JSON Output]", result);
            mockSerializer.Verify(s => s.Serialize(It.IsAny<List<OutputData>>()), Times.Once);
        }
    }
}
