using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Model
{
    public class LogBase
    {
        public string Worker { get; set; }
        public string Date { get; set; }
        public string Operatoin { get; set; }

        public LogBase(string worker, string date, string operatoin) 
        {
            Worker = worker;
            Date = date;
            Operatoin = operatoin;
        }
    }
}
