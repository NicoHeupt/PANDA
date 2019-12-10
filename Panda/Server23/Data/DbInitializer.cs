using System.Linq;
using Server23.Entities;

namespace Server23.Data
{
    public class DbInitializer
    {
        public static void SeedDemoData(IPandaRepository pandaRepo)
        {
            var products = pandaRepo.GetAllProducts();
            if(!products.Any())
            {
                pandaRepo.AddMarketProduct(new MarketProduct("LAX"));
                pandaRepo.IncreaseMarketProductAmount("LAX", 100);
                pandaRepo.SetMarketProductPrice("LAX", 25.50m);

                pandaRepo.AddMarketProduct(new MarketProduct("ISI"));
                pandaRepo.IncreaseMarketProductAmount("ISI", 1000);
                pandaRepo.SetMarketProductPrice("ISI", 3.99m);

                pandaRepo.AddMarketProduct(new MarketProduct("WOT"));
                pandaRepo.IncreaseMarketProductAmount("WOT", 200);
                pandaRepo.SetMarketProductPrice("WOT", 1234567.89m);
            }

            var traders = pandaRepo.GetAllTraders();
            if (!traders.Any())
            {
                pandaRepo.AddNewTrader("WBuffett");
                pandaRepo.AddNewTrader("JBelfort");
                var jb = pandaRepo.GetTraderByName("JBelfort");
                var bt = new BankTransaction(jb, 20000.0m);
                pandaRepo.BookBankTransaction( bt );

                var lax = pandaRepo.GetMarketProduct("LAX");
                var bo = new BookingOrder(jb, lax, 4, 30.0m);
                pandaRepo.PlaceBookingOrder(bo);

                var unbookdBo = pandaRepo.GetBookingOrdersUnbooked();

                pandaRepo.BookBookingOrder(bo);
            }


        }
    }
}
