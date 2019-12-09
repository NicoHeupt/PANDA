using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server31.Entities
{
    public class DepotTransaction
    {
        public int Id { get; set; }

        [ForeignKey("Depot")]
        public int DepotId { get; set; }
        public Depot Depot { get; set; }

        [ForeignKey("Product")]
        public string ProductCode { get; set; }
        public Product Product { get; set; }


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

        /// <summary>
        /// Total price of transaction
        /// </summary>
        [NotMapped]
        public decimal Total => Price * Amount;

        /// <summary>
        /// String like this "Kauf von 200 × LAX à 23,00 €
        /// </summary>
        [NotMapped]
        public string ReasonString => $"{VerbString} von {Amount} × {ProductCode} à {Price.ToString("C")}";

        /// <summary>
        /// return "Kauf" if Amount > 0 or "Verkauf" else
        /// </summary>
        [NotMapped]
        public string VerbString => (Amount > 0) ? "Kauf" : "Verkauf";

        public DateTime Time { get; set; }

        private DepotTransaction()
        {

        }

        public DepotTransaction(Trader trader, MarketProduct marketProduct, int amountPieces)
        {
            Depot = trader.Depot;
            DepotId = trader.Depot.Id;
            Product = marketProduct.Product;
            ProductCode = marketProduct.Product.Code;
            Amount = amountPieces;
            Price = marketProduct.Price;
            Time = DateTime.UtcNow;
        }
    }
}
