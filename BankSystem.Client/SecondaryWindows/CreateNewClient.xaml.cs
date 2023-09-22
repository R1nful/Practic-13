using BankSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BankSystem.Model;

namespace BankSystem.Client.SecondaryWindows
{
    using Client = BankSystem.Model.Client;
    /// <summary>
    /// Логика взаимодействия для CreateNewClient.xaml
    /// </summary>
    public partial class CreateNewClient : Window
    {
        public CreateNewClient()
        {
            InitializeComponent();
        }

        private void CreateClientBtn_Click(object sender, RoutedEventArgs e)
        {
            Client cl = new Client(LastNameFiledTB.Text, NameFiledTB.Text, PatronymicFiledTB.Text, PhoneFiledTB.Text,
                PassportFiledTB.Text, new System.Collections.ObjectModel.ObservableCollection<Invoice>());

            ClientRepository.Add(cl);

            this.Close();
        }
    }
}
