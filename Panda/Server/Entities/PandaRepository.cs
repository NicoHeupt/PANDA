using Microsoft.EntityFrameworkCore;
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
            var foo = context.Traders.Include(trader => trader.BankAccount);
            var bar = context.Traders;
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

        public void AddMarketProduct(MarketProduct marketProduct)
        {
            context.Market.Add(marketProduct);
            context.Products.Add(marketProduct.Product);
            context.SaveChanges();
        }

        #endregion
    }
}
