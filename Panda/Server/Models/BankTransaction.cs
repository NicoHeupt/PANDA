using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class BankTransaction
    {
        public int Id { get; set; }
        public int BankAccountId { get; }
        public BankAccount BankAccount { get; }

        public DateTime Time { get; }
        public decimal Amount { get; }
        public BankAccount Account { get; }
    }
}
