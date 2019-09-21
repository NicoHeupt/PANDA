using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Entities
{
    public class PandaRepository : IPandaRepository
    {
        private readonly PandaDbContext context;

        public PandaRepository(PandaDbContext pandaDbContext)
        {
            context = pandaDbContext;
        }

        #region Traders

        public IEnumerable<Trader> GetAllTraders()
        {
            return context.Traders;
        }

        public Trader GetTraderById(int traderId)
        {
            return context.Traders.FirstOrDefault(t => t.Id == traderId);
        }

        public void AddTrader(Trader trader)
        {
            context.Traders.Add(trader);
            context.SaveChanges();
        }

        #endregion

        #region Products

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products;
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        #endregion
    }
}
