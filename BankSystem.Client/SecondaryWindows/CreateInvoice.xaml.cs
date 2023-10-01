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

namespace Practic_12
{
    /// <summary>
    /// Логика взаимодействия для CreateInvoice.xaml
    /// </summary>
    public partial class CreateInvoice : Window
    {
        private event Action<string> ActionMessage;
        public CreateInvoice(Action<string> message)
        {
            InitializeComponent();

            TypeInvoiseCB.ItemsSource = new string[] { "Депозитный", "Недепозинтый" };
            ClientNameCB.ItemsSource = ClientRepository.clients;

            ActionMessage = message;
        }

        private void CreateInvoiseBtn_Click(object sender, RoutedEventArgs e)
        {
            Client client = ClientNameCB.SelectedItem as Client;
            string typeinv = TypeInvoiseCB.SelectedValue as string;

            Invoice invoice = new Invoice(client.FirstName, 0, true, typeinv);

            client.AddInvoice(invoice);

            ActionMessage?.Invoke($"Открыт новый стчет с номером №{invoice.Number}");

            this.Close();
        }
    }
}
