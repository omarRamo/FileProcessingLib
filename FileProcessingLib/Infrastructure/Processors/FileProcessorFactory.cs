using FileProcessingLib.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessingLib.Infrastructure.Processors
{
    public static class FileProcessorFactory
    {
        public static IFileProcessor Create(List<string> inputLines)
        {
            if (inputLines[0].Contains(";"))
            {
                return new CsvFileProcessor();
            }
            else
            {
                return new FixedWidthFileProcessor();
            }
        }
    }
}
