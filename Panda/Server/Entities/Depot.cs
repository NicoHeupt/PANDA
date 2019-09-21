using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Entities
{
    public class Depot
    {
        public int Id { get; set; }
        public Trader Trader { get; set; }
        public int TraderId { get; set; }

        public ICollection<DepotPosition> Positions { get; set; }
        public ICollection<DepotTransaction> Transactions { get; set; }
    }
}
