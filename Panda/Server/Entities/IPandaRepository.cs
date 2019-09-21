using System.Collections.Generic;

namespace Server.Entities
{
    public interface IPandaRepository
    {
        // Traders
        IEnumerable<Trader> GetAllTraders();
        Trader GetTraderById(int traderId);
        void AddTrader(Trader trader);

        // Products
        IEnumerable<Product> GetAllProducts();
        void AddProduct(Product product);
    }
}
