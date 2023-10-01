using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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

                    switch (trs.TransferMoney(ref transfer, sum))
                    {
                        case 0:
                            ActionMessage?.Invoke($"Переведено {sum}$ с счета №{transfer.Number} на счет №{trs.Number}");
                            break;
                        case 1:
                            MessageBox.Show("Перевод невозможен. Недостаточно Средств");
                            break;
                        case 2:
                            MessageBox.Show("Перевод невозможен. Счет закрыт");
                            break;
                        default:
                            MessageBox.Show("Ошибка перевод невозможен.");
                            break;
                    }
                }
            }
        }

        private void BaseInvoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BaseInvoiceLV.ItemsSource = (BaseInvoice.SelectedItem as Client)?.ClientInvoices;
        }

        private void TransferInvoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TransferInvoiceLV.ItemsSource = (TransferInvoice.SelectedItem as Client)?.ClientInvoices;
        }
    }
}
