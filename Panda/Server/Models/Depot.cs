using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Depot
    {
        public int Id { get; set; }
        public Trader Trader { get; set; }
        public int TraderId { get; set; }

        public List<DepotPosition> Positions { get; set; }
    }
}
