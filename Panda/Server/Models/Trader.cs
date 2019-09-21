using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    /// <summary>
    /// represents a user who can buy and sell products
    /// </summary>
    public class Trader
    {
        public int Id { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Name { get; set; }

        public BankAccount BankAccount { get; set; }
        public Depot Depot { get; set; }
        public List<BookingOrder> BookingOrders { get; set; }
    }
}
