using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using vipief.ViewModel.Helpers;
using Newtonsoft.Json;

namespace vipief.Model
{
    static class Saves
    {
        private static string GetFilePath(DateOnly date)
        {
            string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "saves");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            return Path.Combine(directoryPath, $"{date:dd-MM-yyyy}.json");
        }

        public static void SaveUserChoose(UserChoose choose)
        {
            string filePath = GetFilePath(choose.date);

            SerDes.SerializeToFile(choose, filePath);
        }

        public static UserChoose LoadUserChoose(DateOnly date)
        {
            string filePath = GetFilePath(date);

            return SerDes.DeserializeFromFile<UserChoose>(filePath) ?? new UserChoose(date);
        }
    }
}

