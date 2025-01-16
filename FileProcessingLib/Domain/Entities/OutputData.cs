using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessingLib.Domain.Entities
{
    public class OutputData
    {
        public string OriginalSourceId { get; set; }
        public string TransactionDate { get; set; }
        public decimal Value { get; set; }
        public decimal Rate { get; set; }
    }
}
