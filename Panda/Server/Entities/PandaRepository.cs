using System;
using System.Collections.Generic;
using System.Linq;

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

        public Trader GetTraderByName(string traderName)
        {
            return context.Traders.FirstOrDefault(t => t.Name == traderName);
        }

        public Trader GetTraderByBankAccountId(int bankAccountId)
        {
            return context.Traders.FirstOrDefault(t => t.BankAccountId == bankAccountId);
        }

        public void AddTrader(Trader trader)
        {
            context.Traders.Add(trader);
            context.SaveChanges();
        }

        public void AddNewTrader(string name)
        {
            Trader newTrader = new Trader(name);
            context.Traders.Add(newTrader);
            context.SaveChanges();
        }

        #endregion


        #region Bank

        public decimal BookBankTransaction(BankTransaction transaction)
        {
            Trader trader = GetTraderByBankAccountId(transaction.BankAccountId);
            context.Traders.Update(trader);

            decimal newBalance = trader.BankAccount.Balance + transaction.Amount;
            transaction.Time = DateTime.UtcNow;
            trader.BankAccount.BankTransactions.Add(transaction);
            trader.BankAccount.Balance = newBalance;

            context.SaveChanges();
            return newBalance;
        }

        public BankAccount GetBankAccount(int BankAccountId)
        {
            Trader trader = context.Traders.FirstOrDefault(t => t.BankAccountId == BankAccountId);
            return trader.BankAccount;
        }

        #endregion


        #region Products

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products;
        }

        public Product GetProduct(string code)
        {
            return context.Products.FirstOrDefault(p => p.Code == code);

        }

        #endregion


        #region Market

        public void AddMarketProduct(MarketProduct marketProduct)
        {
            context.Market.Add(marketProduct);
            context.Products.Add(marketProduct.Product);
            context.SaveChanges();
        }

        public IEnumerable<MarketProduct> GetAllMarketProducts()
        {
            return context.Market;
        }

        #endregion

    }
}
