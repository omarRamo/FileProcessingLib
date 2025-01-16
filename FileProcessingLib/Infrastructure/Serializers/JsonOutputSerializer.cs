using FileProcessingLib.Application.Interfaces;
using FileProcessingLib.Domain.Entities;
using System.Text.Json;

namespace FileProcessingLib.Infrastructure.Serializers
{
    public class JsonOutputSerializer : IOutputSerializer
    {
        public string Serialize(List<OutputData> data)
        {
            return JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = false
            });
        }
    }
}
