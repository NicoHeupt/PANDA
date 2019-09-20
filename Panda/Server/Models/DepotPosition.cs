using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class DepotPosition
    {
        public Product Product { get; }

        public int Amount { get; set; }
    }
}
