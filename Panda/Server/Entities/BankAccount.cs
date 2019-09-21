using System.Collections.Generic;

namespace Server.Entities
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int TraderID { get; set; }
        public Trader Trader { get; set; }

        public decimal Balance { get; set; }
        public ICollection<BankTransaction> BankTransactions { get; set; }

        public BankAccount()
        {
            Balance = 0;
        }
    }
}
