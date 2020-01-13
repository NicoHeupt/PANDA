using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server31.Entities
{
    /// <summary>
    /// represents product offerings on the market
    /// </summary>
    public class MarketProduct
    {
        public string MarketProductId { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }
        
        
        /// <summary>
        /// number of pieces available to buy
        /// </summary>
        public int AmountAvailable { get; set; }

        /// <summary>
        /// current price per piece
        /// </summary>
        public decimal Price { get; set; }

        public MarketProduct(string productId)
        {
            ProductId = productId;
            Product = new Product(productId);
            AmountAvailable = Product.AmountOverall;
        }
    }
}
