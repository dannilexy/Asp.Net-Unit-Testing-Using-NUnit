using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
   
    public class BankAccount
    {
        private readonly ILogBook _logbook;

        public int balance { get; set; }
        public BankAccount(ILogBook _logbook)
        {
            this._logbook = _logbook;
            balance = 0;
        }

        public bool Deposit(int amount)
        {
            _logbook.Message("Deposit Invoked"); //returns true
            _logbook.Message("Test"); //returns false
            _logbook.LogSeverity = 101;
            balance += amount;
            return true;
        }
        public bool WithDrawal(int amount)
        {
            if (amount <= balance)
            {
                _logbook.LogToDb("Withdrawal Amount: " + amount.ToString());
                balance -= amount;
                return _logbook.LogBalanceAfterWithdraw(balance);
            }
            _logbook.LogBalanceAfterWithdraw(balance-amount);
            return false;
           
        }

        public int GetBalance()
        {
            return balance;
        }
    }
}
