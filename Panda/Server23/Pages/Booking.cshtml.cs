using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server23.Data;
using Server23.Entities;

namespace Server23
{
    public class BookingModel : PageModel
    {
        private readonly IPandaRepository pandaRepo;

        public BookingModel(IPandaRepository pandaRepository)
        {
            pandaRepo = pandaRepository;
        }

        public List<MarketProduct> Market { get; set; }

        public void OnGet()
        {
            Market = pandaRepo.GetAllMarketProducts()
                .OrderBy(mp => mp.ProductCode)
                .ToList();
        }
    }
}