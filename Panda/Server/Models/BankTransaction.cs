using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class BankTransaction
    {
        public DateTime Time { get; private set; }
        public decimal Amount { get; private set; }
        public BankAccount Account { get; private set; }
    }
}
