using BankSystem.Client.SecondaryWindows;
using BankSystem.Model;
using BankSystem.Exceptions;
using Practic_12;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Security.Cryptography.Xml;

namespace BankSystem.Client.Main
{
    using Client = BankSystem.Model.Client;

    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public event Action<string> ActionMessage;

        BankWorker bnkWr;
        Client client;

        public MainView()
        {
            InitializeComponent();

            ClientCB.ItemsSource = ClientRepository.clients;
            BankWorkerCB.ItemsSource = BankWorkerRepository.bankWorkers;
            
            ActionMessage = e => MessageBox.Show(e);
            ActionMessage += e => LogBaseRepository.Add(new LogBase(bnkWr.Name, DateTime.Now.ToString("HH:mm dd.MM.yy"), e));
        }

        private void BankWorkerCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeClientDataList();
            bnkWr = (BankWorker)BankWorkerCB.SelectedItem;
        }

        private void ClientCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ClientCB.SelectedItem != null)
            {
                ChangeClientDataList();

                client = (Client)ClientCB.SelectedItem;

                ClientInvoiceLV.ItemsSource = (client.ClientInvoices);
            }
        }

        /// <summary>
        /// Отображения полей клиента
        /// </summary>
        private void ChangeClientDataList()
        {
            if (BankWorkerCB.SelectedItem != null && ClientCB.SelectedItem != null)
                ClientDataLB.ItemsSource = Permission.ViewField((BankWorker)BankWorkerCB.SelectedItem, (Client)ClientCB.SelectedItem);
        }

        private void ChangeClientFieldBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ClientDataLB.SelectedItem != null && ClientDataLB.SelectedItem.ToString() != ChangeClientFieldTB.Text)
            {
                switch (Permission.ChangeClientField(bnkWr, ref client, (Active)ClientDataLB.SelectedIndex, ChangeClientFieldTB.Text))
                {
                    case 0:
                        ActionMessage?.Invoke($"{ClientDataLB.SelectedItem} изменено на {ChangeClientFieldTB.Text}");
                        break;
                    default:
                        MessageBox.Show("Ошибка изменения");
                        break;
                }
                ChangeClientDataList();
            }
        }

        private void ClientDataLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientDataLB.SelectedItem != null)
                ChangeClientFieldTB.Text = ClientDataLB.SelectedValue.ToString();
        }

        /// <summary>
        /// Кнопка создания нового клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createNewClientBtn_Click(object sender, RoutedEventArgs e)
        {
            // инициализация формы создания клиента
            CreateNewClient createNewClient = new CreateNewClient();

            if (bnkWr.СanAddNewClient)
            {
                CreateNewClient CreateNewClientWB = new CreateNewClient();
                CreateNewClientWB.ShowDialog();
            }
        }

        /// <summary>
        /// Кнопка сохранения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveInDBBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientRepository.SaveInDB();
            LogBaseRepository.SaveInDB();
            MessageBox.Show("Данные сохранены");
        }

        /// <summary>
        /// Кнопка удаления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeliteClient_Click(object sender, RoutedEventArgs e)
        {
            if (bnkWr.СanRemoveClient)
            {
                if(ClientCB.SelectedItem != null)
                {
                    try
                    {
                        if (ClientInvoiceLV.Items.Count != 0)
                            throw new MyException();

                        Client cl = (ClientCB.SelectedItem as Client);

                        int clientCount = ClientCB.Items.Count - 1;

                        if (clientCount > 0)
                            ClientCB.SelectedIndex = clientCount - 1;
                        else
                        {
                            ClientCB.SelectedIndex = -1;
                            ClientDataLB.ItemsSource = null;
                        }

                        ClientRepository.Remove(cl);
                    }
                    catch(MyException ex) 
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
            }
            else
                MessageBox.Show("Нет прав для удаления");
            
        }

        private void CreateNewInvoice_Click(object sender, RoutedEventArgs e)
        {
            CreateInvoice createInvoice = new CreateInvoice(ActionMessage);

            createInvoice.ShowDialog();
        }

        private void DeliteInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (ClientCB.SelectedItem != null && ClientInvoiceLV.SelectedItem != null)
            {
                Invoice inv = ClientInvoiceLV.SelectedItem as Invoice;
                
                if(ClientInvoiceLV.Items.Count > 1)
                {
                    decimal invBalance = inv.Balance;

                    ActionMessage?.Invoke($"Счет №{inv.Number} закрыт");
                    (ClientCB.SelectedItem as Client).RemoveInvoice(inv);

                    Invoice firstInv = ClientInvoiceLV.Items[0] as Invoice;
                    firstInv.AddBalanse(invBalance);

                }
                else if ((ClientInvoiceLV.Items.Count == 1 && ((Invoice)ClientInvoiceLV.Items[0]).Balance == 0))
                {
                    ActionMessage?.Invoke($"Счет №{inv.Number} закрыт");
                    (ClientCB.SelectedItem as Client).RemoveInvoice(inv);
                }
                else
                {
                    MessageBox.Show("Невозможно закрыть единственный счет с деньгами");
                }
            }
        }

        private void AddInvoice_Click(object sender, RoutedEventArgs e)
        {
            if(ClientInvoiceLV.SelectedItem != null)
            {
                AddBalance form = new AddBalance(ClientInvoiceLV.SelectedItem as Invoice, ActionMessage);

                form.ShowDialog();
            }
        }

        private void TransferInvoice_Click(object sender, RoutedEventArgs e)
        {
            TransferMoney mon = new TransferMoney(ActionMessage);
            mon.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
