using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server31.Entities
{
    /// <summary>
    /// Representation of pieces of a product in a Depot.
    /// Uses Composite Key of ProductCode and DepotId as PK.
    /// </summary>
    [Owned]
    public class DepotPosition
    {
        [ForeignKey("Depot")]
        public int DepotId { get; set; }
        public Depot Depot { get; set; }

        [ForeignKey("Product")]
        public string ProductCode { get; set; }
        public Product Product { get; set; }

        public int Amount { get; set; }
    }
}
