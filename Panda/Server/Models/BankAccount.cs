using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int TraderID { get; set; }
        public Trader Trader { get; set; }

        public decimal Balance { get; set; }
        public List<BankTransaction> BankTransactions { get; set; }
    }
}
