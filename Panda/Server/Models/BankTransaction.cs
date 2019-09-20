using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class BankTransaction
    {
        public DateTime Time { get; }
        public decimal Amount { get; }
        public BankAccount Account { get; }
    }
}
