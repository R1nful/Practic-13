using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Model
{
    static public class BankWorkerRepository
    {
        static public ObservableCollection<BankWorker> bankWorkers { get; private set; } = new ObservableCollection<BankWorker>();

        private static string path = "BankWorkerData.json";

        static BankWorkerRepository()
        {
            bankWorkers = new ObservableCollection<BankWorker>() { new Manager(), new Consultant() };
        }

        /// <summary>
        /// Метод сохранения данных в документ
        /// </summary>
        /// <param name="path"></param>
        static public void SaveInDB(string path)
        {
            DataBase<BankWorker>.SaveDB(path, bankWorkers);
        }

        /// <summary>
        /// Добавление работника банка в лист
        /// </summary>
        /// <param name="bankWorkers"></param>
        static public void Add(BankWorker bankWorkers)
        {
            BankWorkerRepository.bankWorkers.Add(bankWorkers);
        }

        /// <summary>
        /// Удаление работника банка из листа
        /// </summary>
        /// <param name="bankWorkers"></param>
        public static void Remove(BankWorker bankWorkers)
        {
            BankWorkerRepository.bankWorkers.Remove(bankWorkers);
        }
    }
}
