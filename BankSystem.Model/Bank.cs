using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Model
{
    public class Bank
    {
       public void ChangevClientValue( Client client, BankWorker bankWorker, Active action, string newValue)
        {
            short answer = Permission.ChangeClientField(bankWorker, ref client, action, newValue);
        }
    }
}
