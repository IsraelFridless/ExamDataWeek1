using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExamDataWeek1.Service
{
    internal class JsonHandling
    {
        public static T? ReadFromJsonAsync<T>(string filePath, JsonSerializerOptions options = null)
        {
            try
            {
                options ??= new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                T? data = JsonSerializer.Deserialize<T>(
                    File.OpenRead(filePath),
                    options
                );
                return data;
            }
            catch (Exception ex)
            {
                return default;
            }
        }
    }
}
