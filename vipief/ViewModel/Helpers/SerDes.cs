using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace vipief.ViewModel.Helpers
{
    static class SerDes
    {
        public static void SerializeToFile<T>(T obj, string filePath)
        {
            string directory = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string json = JsonSerializer.Serialize(obj);
            File.WriteAllText(filePath, json);
        }

        public static T DeserializeFromFile<T>(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<T>(json);
            }

            return default;
        }
    }
}
