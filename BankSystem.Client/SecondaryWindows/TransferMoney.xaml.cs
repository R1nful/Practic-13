using System;
using System.Windows;
using System.Windows.Controls;
using BankSystem.Model;

namespace BankSystem.Client.SecondaryWindows
{
    using Client = BankSystem.Model.Client;
    
    /// <summary>
    /// Логика взаимодействия для TransferMoney.xaml
    /// </summary>
    public partial class TransferMoney : Window
    {
        private event Action<string> ActionMessage;

        public TransferMoney(Action<string> message)
        {
            InitializeComponent();
            BaseInvoice.ItemsSource = ClientRepository.clients;
            TransferInvoice.ItemsSource = ClientRepository.clients;
            ActionMessage = message;
        }

        private void TransferBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BaseInvoiceLV.SelectedItem != null && TransferInvoiceLV.SelectedItem!= null)
            {
                if (decimal.TryParse(TransferSumTB.Text, out decimal sum))
                {
                    Invoice transfer = (Invoice)TransferInvoiceLV.SelectedItem;

                    Invoice trs = (Invoice)BaseInvoiceLV.SelectedItem;

                    trs.TransferMoney(ref transfer, sum);

                    ActionMessage?.Invoke($"Переведено {sum}$ с счета №{transfer.Number} на счет №{trs.Number}");
                }
            }
        }

        private void BaseInvoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BaseInvoiceLV.ItemsSource = (BaseInvoice.SelectedItem as Client).ClientInvoices;
        }

        private void TransferInvoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TransferInvoiceLV.ItemsSource = (TransferInvoice.SelectedItem as Client).ClientInvoices;
        }
    }
}
