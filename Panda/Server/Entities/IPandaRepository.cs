using System.Collections.Generic;

namespace Server.Entities
{
    public interface IPandaRepository
    {
        // Traders
        IEnumerable<Trader> GetAllTraders();
        Trader GetTraderById(int traderId);
        Trader GetTraderByName(string traderName);
        void AddTrader(Trader trader);

        // Bank
        /// <summary>Move cash. Returns new BankAccount balance.</summary>
        decimal BookBankTransaction(BankTransaction transaction);

        // Products
        IEnumerable<Product> GetAllProducts();
        void AddMarketProduct(MarketProduct marketProduct);
    }
}
