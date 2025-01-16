using FileProcessingLib.Application.Interfaces;
using FileProcessingLib.Domain.Exceptions;
using FileProcessingLib.Infrastructure.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessingLib.Application.Services
{
    public class FileProcessingService : IFileProcessingService
    {
        private readonly IOutputSerializer _serializer;

        public FileProcessingService(IOutputSerializer serializer)
        {
            _serializer = serializer;
        }

        public string ProcessFile(List<string> fileLines)
        {
            if (fileLines == null || fileLines.Count == 0)
                throw new InvalidFileFormatException("Input file is empty.");

            var processor = FileProcessorFactory.Create(fileLines);
            var outputData = processor.Process(fileLines);
            return _serializer.Serialize(outputData);
        }
    }
}
