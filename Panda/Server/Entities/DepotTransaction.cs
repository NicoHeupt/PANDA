using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Entities
{
    public class DepotTransaction
    {
        public int Id { get; set; }

        public Depot Depot { get; set; }
        public int DepotId { get; set; }
        
        public Product Product { get; set; }
        public int ProductId { get; set; }

        /// <summary>
        /// number of pieces sold
        /// positive value means Trader BUYS from market
        /// negative value means Trader SELLS to market
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// price per piece that was paid
        /// </summary>
        public decimal Price { get; set; }

        public DateTime Time { get; set; }
    }
}
