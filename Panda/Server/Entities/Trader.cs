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

        //[ForeignKey("BankAccount")]
        //public int BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }

        //[ForeignKey("Depot")]
        //public int DepotId { get; set; }
        public Depot Depot { get; set; }

        public ICollection<BookingOrder> BookingOrders { get; set; }

        private Trader()
        {

        }

        public Trader(string name)
        {
            Name = name;
            BankAccount = new BankAccount();
            Depot = new Depot();
        }
    }
}
