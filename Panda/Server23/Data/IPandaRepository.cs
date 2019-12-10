using Server23.Entities;
using System.Collections.Generic;

namespace Server23.Data
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
        MarketProduct GetMarketProduct(string productCode);
        int IncreaseMarketProductAmount(string productCode, int addedAmount);
        decimal SetMarketProductPrice(string productCode, decimal newPrice);

        /// <summary>Add a product to the market. Generates a MarketProduct and a Product entity.</summary>
        void AddMarketProduct(MarketProduct marketProduct);
        

        // Depot
        BookingOrder GetBookingOrder(int id);
        IEnumerable<BookingOrder> GetBookingOrdersUnbooked();
        IEnumerable<BookingOrder> GetBookingOrdersByTrader();
        void PlaceBookingOrder(BookingOrder bookingOrder);
        void BookBookingOrder(BookingOrder bookingOrder);
    }
}
