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
                using (StreamReader file = File.OpenText(path))
                {
                    string json = file.ReadToEnd();
                    loadedList = JsonConvert.DeserializeObject<List<T>>(json);
                }
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
