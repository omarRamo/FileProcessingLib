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
    public class FixedWidthFileProcessor : IFileProcessor
    {
        public List<OutputData> Process(List<string> inputLines)
        {
            var result = new List<OutputData>();
            foreach (var line in inputLines)
            {
                if (line.Length < 27) throw new FormatException();

                result.Add(new OutputData
                {
                    OriginalSourceId = line.Substring(0, 4).Trim(),
                    TransactionDate = DateTime.ParseExact(line.Substring(4, 10).Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"),
                    Value = decimal.Parse(line.Substring(14, 8).Trim(), CultureInfo.InvariantCulture),
                    Rate = decimal.Parse(line.Substring(22, 5).Trim(), CultureInfo.InvariantCulture)
                });
            }
            return result;
        }
    }
}
