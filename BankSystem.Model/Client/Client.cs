using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BankSystem.Model
{
    public class Client : INotifyPropertyChanged, IComparable
    {
        public ObservableCollection<Invoice> ClientInvoices { get; private set; }

        private string lastName; 
        private string firstName; 
        private string patronymic; 
        private string phone; 
        private string passport; 

        public string LastName 
        {
            get 
            { 
                return lastName;
            }

            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string FirstName 
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string Patronymic 
        {
            get
            {
                return patronymic;
            }

            set
            {
                patronymic = value;
                OnPropertyChanged("Patronymic");
            }
        }
        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }
        public string Passport 
        {
            get
            {
                return passport;
            }

            set
            {
                passport = value;
                OnPropertyChanged("Passport");
            }
        }

        public Client(string lastName, string firstName, string patronymic, string phone, string passport, ObservableCollection<Invoice> clientInvoices)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Patronymic = patronymic;
            this.Phone = phone;
            this.Passport = passport;
            this.ClientInvoices = clientInvoices;
        }

        public void AddInvoice(Invoice invoice)
        {
            ClientInvoices.Add(invoice);
        }

        public void RemoveInvoice(Invoice invoice)
        {
            ClientInvoices.Remove(invoice);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public int CompareTo(object? obj)
        {
            if(obj is Client client)
                return LastName.CompareTo(client.LastName);
            else
                throw new ArgumentException("Некорректное значение параметра");
        }
    }
}
