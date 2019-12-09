using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server31.Entities
{
    /// <summary>
    /// A planned Transaction. BookingOrders are queued and only executed if a threshold price is met.
    /// </summary>
    public class BookingOrder
    {
        public int Id { get; private set; }

        public Trader Trader { get; private set; }
        public int TraderId { get; private set; }


        [ForeignKey("MarketProduct")]
        public string ProductCode { get; set; }
        public MarketProduct MarketProduct { get; private set; }

        /// <summary>
        /// True if Order has been booked successfully
        /// </summary>
        public bool Booked { get; set; }
        
        /// <summary>
        /// Number of pieces sold.
        /// Positive Amount: Trader BUYS from market
        /// Negative Amount: Trader SELLS to market
        /// </summary>
        public int Amount { get; private set; }

        /// <summary>
        /// Threshold price per piece that has to be reached to make a transaction
        /// With positive Amount (Trader buying): This is the highest price that will be payed.
        /// With negative Amount (Trader selling): This is the lowest price it will be sold for.
        /// </summary>
        public decimal Threshold { get; private set; }

        private BookingOrder()
        {

        }

        public BookingOrder(Trader trader, MarketProduct marketProduct, int amount, decimal threshold)
        {
            Trader = trader;
            TraderId = trader.Id;
            MarketProduct = marketProduct;
            ProductCode = marketProduct.ProductCode;
            Amount = amount;
            Threshold = threshold;
            Booked = false;
        }
    }
}
