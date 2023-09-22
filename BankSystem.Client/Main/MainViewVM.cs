using Prism.Mvvm;
using System;
using BankSystem.Model;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Collections.Generic;

namespace BankSystem.Client.Main
{
    using Client = BankSystem.Model.Client;

    public class MainViewVM : BindableBase //, INotifyPropertyChanged
    {
        public ObservableCollection<string> ClientsName { get; }  = new ObservableCollection<string>();
        public ObservableCollection<string> BankWorkersName { get; } = new ObservableCollection<string>();

        public MainViewVM()
        {
            if (BankWorkerRepository.bankWorkers != null)
                foreach (BankWorker e in BankWorkerRepository.bankWorkers)
                    BankWorkersName.Add(e.Name);
                

            if (ClientRepository.clients != null)
                foreach (Client e in ClientRepository.clients)
                    ClientsName?.Add(e.LastName);
        }
    }

    public class ClientVM
    {
        public ClientVM()
        {
            ClientsRP = ClientRepository.clients;
        }

        public ObservableCollection<Client> ClientsRP { get; }
        public string Value = "yes yes";
    }
}
