using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entities
{
    public class BankTransaction
    {
        public int Id { get; set; }

        public BankAccount BankAccount { get; set; }

        public DateTime Time { get; set; }
        public decimal Amount { get; set; }
        public string Reason { get; set; }

        public BankTransaction()
        {

        }

        public BankTransaction(BankAccount bankAccount, decimal amount)
        {
            BankAccount = bankAccount;
            Amount = amount;
        }

        public BankTransaction(Trader trader, decimal amount) : this(trader.BankAccount, amount) 
        {
            BankAccount = trader.BankAccount;
        }
    }
}
