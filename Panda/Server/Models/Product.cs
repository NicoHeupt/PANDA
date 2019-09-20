using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    /// <summary>
    /// represents something that can be traded on the market
    /// </summary>
    public class Product
    {
        /// <summary>
        /// unique three letter code to identify the product, e.g. "LAX"
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// number of pieces that have been introduced until now
        /// </summary>
        public int AmountOverall { get; set; }
    }
}
