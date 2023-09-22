using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Model
{
    public class LogBaseRepository
    {
        static public ObservableCollection<LogBase> LogBases { get; private set; } = new ObservableCollection<LogBase>();

        private static string path = "Log.json";



        /// <summary>
        /// Метод сохранения данных в документ
        /// </summary>
        /// <param name="path"></param>
        static public void SaveInDB(string path)
        {
            DataBase<LogBase>.AddInDB(path, LogBases);
        }

        /// <summary>
        /// Метод сохранения данных в документ
        /// </summary>
        /// <param name="path"></param>
        static public void SaveInDB()
        {
            DataBase<LogBase>.AddInDB(path, LogBases);
        }

        /// <summary>
        /// Добавление клиента в лист
        /// </summary>
        /// <param name="client"></param>
        static public void Add(LogBase log)
        {
            LogBases.Add(log);
        }

        /// <summary>
        /// Удаление клиента из листа
        /// </summary>
        /// <param name="client"></param>
        public static void Remove(LogBase log)
        {
            LogBases.Remove(log);
        }
    }
}
