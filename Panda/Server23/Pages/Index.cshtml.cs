using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server23.Data;
using Server23.Entities;

namespace Server23.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPandaRepository pandaRepo;

        public IndexModel(IPandaRepository pandaRepository)
        {
            pandaRepo = pandaRepository;
        }

        public List<MarketProduct> Market { get; set; }
        public List<Trader> Traders { get; set; }

        //public List<BookingOrder> BookingOrders { get; set; }

        public void OnGet()
        {
            Market = pandaRepo.GetAllMarketProducts()
                .OrderBy(mp => mp.ProductCode)
                .ToList();

            Traders = pandaRepo.GetAllTraders()
                .OrderBy(t => t.BankAccount.Balance)
                .Reverse()
                .ToList();
        }
    }
}
