using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using vipief.ViewModel.Helpers;


namespace vipief.Model
{
    static class Saves
    {
        private static string GetFilePath(DateOnly date)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "saves", $"{date:dd-MM-yyyy}.json");
        }

        public static void SaveUserChoose(UserChoose choose)
        {
            string filePath = GetFilePath(choose.date);

            if (choose.items.Count == 0)
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                return;
            }

            SerDes.SerializeToFile(choose.items, filePath);
        }

        public static UserChoose LoadUserChoose(DateOnly date)
        {
            string filePath = GetFilePath(date);
            UserChoose choose = new(date);

            var items = SerDes.DeserializeFromFile<List<string>>(filePath);
            choose.items = items ?? new List<string>();

            return choose;
        }
    }
}

