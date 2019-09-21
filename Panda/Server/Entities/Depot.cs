using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Server.Entities
{
    public class Depot
    {
        public int Id { get; set; }
        public Trader Trader { get; set; }
        public int TraderId { get; set; }

        public ICollection<DepotPosition> Positions { get; set; } = new Collection<DepotPosition>();
        public ICollection<DepotTransaction> Transactions { get; set; } = new Collection<DepotTransaction>();
    }
}
