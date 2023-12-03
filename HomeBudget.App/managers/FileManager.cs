using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBudget.Domain.Common;
using Newtonsoft.Json;

namespace HomeBudget.App.managers
{
    public class FileManager<T> where T : BaseEntity
    {
        public static List<T> LoadListFronFile(string path)
        {
            List<T> loadedList = new List<T>();
            if (File.Exists(path)) 
            {
                string json = File.ReadAllText(path);
                loadedList = JsonConvert.DeserializeObject<List<T>>(json);
            }
            else 
            {
                Console.WriteLine("File not found");
            }
            return loadedList;
        }

        public static void SaveListToFile(List<T> list, string path)
        {
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText(path, json);
        }
    }
}
