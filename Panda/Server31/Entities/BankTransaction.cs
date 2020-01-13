using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server31.Entities
{
    public class BankTransaction
    {
        public int BankTransactionId { get; set; }

        public int BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }

        public DateTime Time { get; set; }
        public decimal Amount { get; set; }
        public string Reason { get; set; }

        public BankTransaction()
        {

        }

        public BankTransaction(BankAccount bankAccount, decimal amount, string reason = "")
        {
            BankAccount = bankAccount;
            Amount = amount;
            Reason = reason;
        }

        public BankTransaction(Trader trader, decimal amount, string reason = "") : this(trader.BankAccount, amount, reason) 
        {
            BankAccount = trader.BankAccount;
        }

    }
}
