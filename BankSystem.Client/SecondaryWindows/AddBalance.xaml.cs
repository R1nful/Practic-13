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

namespace BankSystem.Client.SecondaryWindows
{
    /// <summary>
    /// Логика взаимодействия для AddBalance.xaml
    /// </summary>
    public partial class AddBalance : Window
    {
        Invoice invoice;
        private event Action<string> ActionMessage;
        public AddBalance(Invoice _invoice, Action<string> message)
        {
            InitializeComponent();
            invoice = _invoice;
            ActionMessage = message;
        }

        private void AddBalanceBtn_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(AddBalanceField.Text, out decimal sum))
            {
                invoice.AddBalanse(sum);
                ActionMessage.Invoke($"{sum}$ добавлены на счет №{invoice.Number}");
                this.Close();
            }
            else
                MessageBox.Show("Введите корректное значение");
        }
    }
}
