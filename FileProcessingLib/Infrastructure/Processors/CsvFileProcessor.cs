using FileProcessingLib.Application.Interfaces;
using FileProcessingLib.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessingLib.Infrastructure.Processors
{
    public class CsvFileProcessor : IFileProcessor
    {
        public List<OutputData> Process(List<string> inputLines)
        {
            var result = new List<OutputData>();
            foreach (var line in inputLines.Skip(1)) 
            {
                var parts = line.Split(';');
                if (parts.Length != 4) throw new FormatException("Invalid CSV format.");

                result.Add(new OutputData
                {
                    OriginalSourceId = parts[0],
                    TransactionDate = DateTime.Parse(parts[1], CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"),
                    Value = decimal.Parse(parts[2], CultureInfo.InvariantCulture),
                    Rate = decimal.Parse(parts[3], CultureInfo.InvariantCulture)
                });
            }
            return result;
        }
    }
}
