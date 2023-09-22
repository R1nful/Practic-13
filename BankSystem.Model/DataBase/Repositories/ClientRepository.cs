using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace BankSystem.Model
{
    static public class ClientRepository
    {
        static public ObservableCollection<Client> clients { get; private set; } = new ObservableCollection<Client>();

        private static string path = "ClientData.json";

        static ClientRepository()
        {
            clients = DataBase<Client>.LoadDB(path);
        }

        /// <summary>
        /// Метод сохранения данных в документ
        /// </summary>
        /// <param name="path"></param>
        static public void SaveInDB(string path)
        {
            DataBase<Client>.SaveDB(path, clients);
        }
        
        /// <summary>
        /// Метод сохранения данных в документ
        /// </summary>
        /// <param name="path"></param>
        static public void SaveInDB()
        {
            DataBase<Client>.SaveDB(path, clients);
        }

        /// <summary>
        /// Добавление клиента в лист
        /// </summary>
        /// <param name="client"></param>
        static public void Add(Client client)
        {
            clients.Add(client);
        }

        /// <summary>
        /// Удаление клиента из листа
        /// </summary>
        /// <param name="client"></param>
        public static void Remove(Client client) 
        {
            clients.Remove(client); 
        }
    }
}
