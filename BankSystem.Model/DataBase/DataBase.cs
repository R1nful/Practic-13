using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace BankSystem.Model
{
    static public class DataBase<T>
    {
        /// <summary>
        /// Записывает данные из ObservableCollection в файл
        /// </summary>
        /// <param name="path"></param>
        /// <param name="date"></param>
        static public void SaveDB(string path, ObservableCollection<T> date)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings 
            {
                TypeNameHandling = TypeNameHandling.All
            };

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                string text = JsonConvert.SerializeObject(date, Formatting.Indented);
                streamWriter.WriteLine(text);
            }
        }

        /// <summary>
        /// Чтание из файла и возвращает значание в ObservableCollection
        /// </summary>
        /// <param name="path"></param>
        /// <param name="clients"></param>
        static public ObservableCollection<T> LoadDB(string path)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            ObservableCollection<T> date;

            using (StreamReader streamReader = new StreamReader(path))
            {
                string text = streamReader.ReadToEnd();
                date = JsonConvert.DeserializeObject<ObservableCollection<T>>(text);
            }

            return date;
        }

        static public void AddInDB(string path, ObservableCollection<T> date)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            using (StreamWriter streamWriter = new StreamWriter(path, true))
            {
                string text = JsonConvert.SerializeObject(date, Formatting.Indented);

                streamWriter.Write(text);
                //streamWriter.WriteLine(text);
            }
        }
    }
}
