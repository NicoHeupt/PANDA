using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Entities;

namespace Server.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPandaRepository pandaRepo;

        public IndexModel(IPandaRepository pandaRepository)
        {
            pandaRepo = pandaRepository;
        }
        

        public List<Trader> Traders { get; set; }
        public List<Product> Products { get; set; }
        //public List<MarketProduct> Market { get; set; }
        //public List<BookingOrder> BookingOrders { get; set; }

        public void OnGet()
        {
            Traders = pandaRepo.GetAllTraders().ToList();
            Products = pandaRepo.GetAllProducts().ToList();
        }
    }
}