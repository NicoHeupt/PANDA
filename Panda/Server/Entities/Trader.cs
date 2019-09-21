using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Entities
{
    /// <summary>
    /// represents a user who can buy and sell products
    /// </summary>
    public class Trader
    {
        public int Id { get; private set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Name { get; set; }

        [ForeignKey("BankAccount")]
        public int BankAccountId { get; private set; }
        public BankAccount BankAccount { get; private set; } = new BankAccount();

        [ForeignKey("Depot")]
        public int DepotId { get; private set; }
        public Depot Depot { get; private set; } = new Depot();

        public ICollection<BookingOrder> BookingOrders { get; set; }

        public Trader(string name)
        {
            Name = name;
        }
    }
}
