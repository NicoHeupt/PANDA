using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Server31.Entities
{
    [Owned]
    public class Depot
    {
        public int Id { get; set; }
        public Trader Trader { get; set; }
        public ICollection<DepotPosition> Positions { get; set; } = new Collection<DepotPosition>();
        public ICollection<DepotTransaction> Transactions { get; set; } = new Collection<DepotTransaction>();

        /// <summary>
        /// Get DepotPosition of a given product.
        /// If Depot has no position of the product, a new one is added.
        /// </summary>
        public DepotPosition GetPosition(Product product)
        {
            try
            {
                return Positions.First(dp => dp.ProductCode == product.Code);
            }
            catch (InvalidOperationException) // no match
            {
                var newPosition = new DepotPosition
                {
                    Product = product,
                    ProductCode = product.Code,
                    Amount = 0,
                    Depot = this,
                    DepotId = this.Id
                };
                Positions.Add(newPosition);
                return newPosition;
            }
        }
    }
}
