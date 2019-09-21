using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class DbInitializer
    {
        public static void SeedDemoData(IPandaRepository pandaRepository)
        {
            var traders = pandaRepository.GetAllTraders();
            if (!traders.Any())
            {
                var newTrader = new Trader("JBelfort");
                pandaRepository.AddTrader(newTrader);
            }
            traders = pandaRepository.GetAllTraders();
        }
    }
}
