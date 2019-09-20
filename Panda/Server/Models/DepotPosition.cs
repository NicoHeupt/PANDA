using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class DepotPosition
    {
        public int Id { get; }
        public Depot Depot { get; }
        public int DepotId { get; set; }

        public Product Product { get; }
        public int Amount { get; set; }
    }
}
