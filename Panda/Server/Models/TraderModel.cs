using Server.Entities;
using System.Collections.Generic;

namespace Server.Models
{
    public class TraderModel
    {
        public int Id { get; private set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Name { get; set; }

        public int BankAccountId { get; private set; }
        //public BankAccount BankAccount { get; private set; } = new BankAccount();
        //TODO: hypermedia link zum bankaccount via api
        //TODO: maybe add balance here?

        public int DepotId { get; private set; }
        //public Depot Depot { get; private set; } = new Depot();
        //TODO: hypermedia link zum bankaccount via api

        //public ICollection<BookingOrder> BookingOrders { get; set; }
        //TODO: offene bookingorders?

        public TraderModel(Trader trader)
        {
            Id = trader.Id;
            Name = trader.Name;
            BankAccountId = trader.BankAccountId;
            DepotId = trader.DepotId;
        }
    }
}
