using BankSystem.Model;
using System;
using System.Windows.Controls;

namespace BankSystem.Exceptions
{
    public class MyException : Exception
    {
        public override string Message => "� ������� ���� ���������� �����";
        public MyException()
        {
        }
    }
}
