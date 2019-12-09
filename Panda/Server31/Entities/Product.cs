using System.ComponentModel.DataAnnotations;

namespace Server31.Entities
{
    /// <summary>
    /// represents something that can be traded on the market
    /// </summary>
    public class Product
    {
        /// <summary>
        /// unique three letter code to identify the product, e.g. "LAX"
        /// </summary>
        [Key]
        public string Code { get; set; }

        /// <summary>
        /// number of pieces that have been introduced until now
        /// </summary>
        public int AmountOverall { get; set; }

        public Product(string code)
        {
            Code = code;
        }
    }
}
