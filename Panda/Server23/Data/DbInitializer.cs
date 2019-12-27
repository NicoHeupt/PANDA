using System.Data;
using System.Linq;
using Server23.Entities;

namespace Server23.Data
{
    public class DbInitializer
    {
        public static void SeedInitialProductData(IPandaRepository pandaRepo)
        {
            var products = pandaRepo.GetAllProducts();
            if (!products.Any())
            {
                SetupProduct(pandaRepo, "LAX", 100, 0.01m);
                SetupProduct(pandaRepo, "WOT", 1000, 0.01m);
                SetupProduct(pandaRepo, "YSI", 10000, 0.01m);
                SetupProduct(pandaRepo, "NWA", 2000, 0.01m);
                SetupProduct(pandaRepo, "RPI", 2100, 0.01m);
                SetupProduct(pandaRepo, "LOL", 2500, 0.01m);
                SetupProduct(pandaRepo, "SXE", 200, 0.01m);
                SetupProduct(pandaRepo, "RAW", 400, 0.01m);
                SetupProduct(pandaRepo, "FCK", 5000, 0.01m);
            }
        }

        private static void SetupProduct(IPandaRepository pandaRepo, string productCode, int initialAmount, decimal initalPrice)
        {
            pandaRepo.AddMarketProduct(new MarketProduct(productCode));
            pandaRepo.IncreaseMarketProductAmount(productCode, initialAmount);
            pandaRepo.SetMarketProductPrice(productCode, initalPrice);
        }

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
