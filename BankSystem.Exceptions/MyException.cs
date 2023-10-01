using BankSystem.Model;
using System;
using System.Windows.Controls;

namespace BankSystem.Exceptions
{
    public class MyException : Exception
    {
        public MyException()
        {

        }
        public MyException(string msg, ItemCollection IncoiceList) : base(msg)
        {
            if (IncoiceList != null)
            {
                foreach(Invoice inv in IncoiceList)
                {
                    if (inv.Balance > 0)
                        throw new Exception("У клиента еще есть не 0 счета");
                }
            }
        }
    }
}
