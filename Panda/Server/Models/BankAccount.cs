using System.Collections.Generic;

namespace Server.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int TraderID { get; set; }
        public Trader Trader { get; set; }

        public decimal Balance { get; set; }
        public ICollection<BankTransaction> BankTransactions { get; set; }
    }
}
