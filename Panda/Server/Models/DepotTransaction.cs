using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class DepotTransaction
    {
        public Product Product { get; }

        /// <summary>
        /// number of pieces sold
        /// positive value means Trader BUYS from market
        /// negative value means Trader SELLS to market
        /// </summary>
        public int Amount { get; }

        /// <summary>
        /// price per piece that was paid
        /// </summary>
        public decimal Price { get; }

        public DateTime Time { get; }
    }
}
