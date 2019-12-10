using Microsoft.EntityFrameworkCore;
using Server23.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server23.Data
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
            return context.Traders
                .Include(t => t.BankAccount)
                .Include(t => t.Depot);
        }

        public Trader GetTraderById(int traderId)
        {
            return context.Traders
                .Include(t => t.BankAccount)
                .Include(t => t.Depot)
                .FirstOrDefault(t => t.Id == traderId);
        }

        public Trader GetTraderByName(string traderName)
        {
            return context.Traders
                .Include(t => t.BankAccount)
                .Include(t => t.Depot)
                .FirstOrDefault(t => t.Name == traderName);
        }

        public Trader GetTraderByBankAccount(BankAccount bankAccount)
        {
            return context.Traders.FirstOrDefault(t => t.BankAccount.Id == bankAccount.Id);
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
            Trader trader = GetTraderByBankAccount(transaction.BankAccount);
            context.Traders.Update(trader);

            decimal newBalance = trader.BankAccount.Balance + transaction.Amount;
            transaction.Time = DateTime.UtcNow;
            trader.BankAccount.BankTransactions.Add(transaction);
            trader.BankAccount.Balance = newBalance;

            context.SaveChanges();
            return newBalance;
        }

        //public BankAccount GetBankAccount(int BankAccountId)
        //{
        //    Trader trader = context.Traders.FirstOrDefault(t => t.BankAccountId == BankAccountId);
        //    return trader.BankAccount;
        //}

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

        public MarketProduct GetMarketProduct(string productCode)
        {
            return context.Market.FirstOrDefault(mp => mp.ProductCode == productCode);
        }

        public int IncreaseMarketProductAmount(string productCode, int addedAmount)
        {
            var marketProduct = GetMarketProduct(productCode);
            context.Market.Update(marketProduct);

            marketProduct.AmountAvailable += addedAmount;

            context.SaveChanges();
            return marketProduct.AmountAvailable;
        }

        public decimal SetMarketProductPrice(string productCode, decimal newPrice)
        {
            var marketProduct = GetMarketProduct(productCode);
            context.Market.Update(marketProduct);

            marketProduct.Price = newPrice;

            context.SaveChanges();
            return marketProduct.Price;
        }

        #endregion

        public BookingOrder GetBookingOrder(int id)
        {
            return context.BookingOrders.FirstOrDefault(bo => bo.Id == id);
        }

        public IEnumerable<BookingOrder> GetBookingOrdersUnbooked()
        {
            return context.BookingOrders.Where(bo => !bo.Booked);
        }

        public IEnumerable<BookingOrder> GetBookingOrdersByTrader(Trader trader)
        {
            return context.BookingOrders.Where(bo => bo.Trader.Id == trader.Id);
        }

        public void PlaceBookingOrder(BookingOrder bookingOrder)
        {
            context.BookingOrders.Add(bookingOrder);
            context.SaveChanges();
        }

        public void BookBookingOrder(BookingOrder bookingOrder)
        {
            var marketProduct = GetMarketProduct(bookingOrder.MarketProduct.ProductCode);

            if(marketProduct.Price <= bookingOrder.Threshold)
            {
                var trader = GetTraderById(bookingOrder.Trader.Id);
                context.Traders.Update(trader);
                context.Market.Update(marketProduct);

                var depotTransaction = new DepotTransaction(trader, marketProduct, bookingOrder.Amount);

                var bankTransaction = new BankTransaction(trader, -depotTransaction.Total, depotTransaction.ReasonString); //TODO: Verwendungszweck
                BookBankTransaction(bankTransaction);

                var depotPosition = trader.Depot.GetPosition(marketProduct.Product);
                depotPosition.Amount += depotTransaction.Amount;

                context.SaveChanges();
            }
        }

        public IEnumerable<BookingOrder> GetBookingOrdersByTrader()
        {
            throw new NotImplementedException();
        }

    }
}
