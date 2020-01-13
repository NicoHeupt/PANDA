using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server31.Entities
{
    /// <summary>
    /// Representation of pieces of a product in a Depot.
    /// Uses Composite Key of ProductId and DepotId as PK.
    /// </summary>
    public class DepotPosition
    {
        public int DepotPositionId { get; set; }

        public int DepotId { get; set; }
        public Depot Depot { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }

        public int Amount { get; set; }
    }
}
