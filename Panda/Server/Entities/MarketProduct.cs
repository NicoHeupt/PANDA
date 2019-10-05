using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entities
{
    /// <summary>
    /// represents product offerings on the market
    /// </summary>
    public class MarketProduct
    {
        [Key]
        [ForeignKey("Product")]
        public string ProductCode { get; set; }
        public Product Product { get; set; }
        
        
        /// <summary>
        /// number of pieces available to buy
        /// </summary>
        public int AmountAvailable { get; set; }

        /// <summary>
        /// current price per piece
        /// </summary>
        public decimal Price { get; set; }

        public MarketProduct(string productCode)
        {
            ProductCode = productCode;
            Product = new Product(productCode);
            AmountAvailable = Product.AmountOverall;
        }
    }
}
