using System.Linq;

namespace Server.Entities
{
    public class DbInitializer
    {
        public static void SeedDemoData(IPandaRepository pandaRepo)
        {
            var products = pandaRepo.GetAllProducts();
            if(!products.Any())
            {
                pandaRepo.AddMarketProduct(new MarketProduct("LAX"));
                pandaRepo.AddMarketProduct(new MarketProduct("ISI"));
                pandaRepo.AddMarketProduct(new MarketProduct("WOT"));
            }

            var traders = pandaRepo.GetAllTraders();
            if (!traders.Any())
            {
                pandaRepo.AddTrader(new Trader("WBuffett"));
                
                var jb = new Trader("JBelfort");
                pandaRepo.AddTrader(jb);
                var bt = new BankTransaction(jb, 20.0m);
                pandaRepo.BookBankTransaction( bt );

            }


        }
    }
}
