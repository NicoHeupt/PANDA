using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Depot
    {
        public int Id { get; }
        public Trader Trader { get; }
        public int TraderId { get; }

        public List<DepotPosition> Positions { get; private set; }
    }
}
