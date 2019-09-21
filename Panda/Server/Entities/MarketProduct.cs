using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Entities
{
    /// <summary>
    /// represents product offerings on the market
    /// </summary>
    public class MarketProduct
    {
        public int Id { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
        
        /// <summary>
        /// number of pieces available to buy
        /// </summary>
        public int AmountAvailable { get; set; }

        /// <summary>
        /// current price per piece
        /// </summary>
        public decimal Price { get; set; }
    }
}
