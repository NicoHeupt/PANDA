using Server23.Entities;
using System.Collections.Generic;

namespace Server23.Models
{
    public class TraderModel
    {
        public int Id { get; private set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Name { get; set; }

        public BankAccount BankAccount { get; private set; }
        //public BankAccount BankAccount { get; private set; } = new BankAccount();
        //TODO: hypermedia link zum bankaccount via api
        //TODO: maybe add balance here?

        public Depot Depot { get; private set; }
        //public Depot Depot { get; private set; } = new Depot();
        //TODO: hypermedia link zum bankaccount via api

        //public ICollection<BookingOrder> BookingOrders { get; set; }
        //TODO: offene bookingorders?

        public decimal BankBalance { get; set; } //TODO: remove this

        public TraderModel(Trader trader)
        {
            Id = trader.Id;
            Name = trader.Name;
            BankAccount = trader.BankAccount;
            Depot = trader.Depot;
            BankBalance = trader.BankAccount.Balance;
        }
    }
}
