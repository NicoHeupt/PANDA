using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entities
{
    public class BankTransaction
    {
        public int Id { get; set; }

        [ForeignKey("BankAccount")]
        public int BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }

        public DateTime Time { get; set; }
        public decimal Amount { get; set; }

        public BankTransaction(int bankAccountId, decimal amount)
        {
            BankAccountId = bankAccountId;
            Amount = amount;
        }

        public BankTransaction(Trader trader, decimal amount) : this(trader.BankAccountId, amount) 
        {
            BankAccount = trader.BankAccount;
        }
    }
}
