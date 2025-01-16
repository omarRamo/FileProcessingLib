using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessingLib.Application.Interfaces
{
    public interface IFileProcessingService
    {
        string ProcessFile(List<string> fileLines);
    }
}
