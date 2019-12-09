using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Server31.Entities
{

    public class BankAccount
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public Trader Trader { get; set; }
        public ICollection<BankTransaction> BankTransactions { get; set; } = new Collection<BankTransaction>();
    }
}
