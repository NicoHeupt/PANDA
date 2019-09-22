using System.Collections.Generic;

namespace Server.Entities
{
    public interface IPandaRepository
    {
        // Traders
        IEnumerable<Trader> GetAllTraders();
        Trader GetTraderById(int traderId);
        Trader GetTraderByName(string traderName);
        void AddNewTrader(string name);

        // Bank
        /// <summary>Move cash. Returns new BankAccount balance.</summary>
        decimal BookBankTransaction(BankTransaction transaction);

        // Products
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(string code);

        // Market
        IEnumerable<MarketProduct> GetAllMarketProducts();

        /// <summary>Add a product to the market. Generates a MarketProduct and a Product entity.</summary>
        void AddMarketProduct(MarketProduct marketProduct);
    }
}
