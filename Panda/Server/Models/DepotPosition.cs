using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class DepotPosition
    {
        public int Id { get; set; }
        public Depot Depot { get; set; }
        public int DepotId { get; set; }

        public Product Product { get; set; }
        public int Amount { get; set; }
    }
}
