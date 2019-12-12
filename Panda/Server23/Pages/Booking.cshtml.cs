using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server23.Data;
using Server23.Entities;
using Server23.Enums;
using Server23.Helpers;

namespace Server23
{
    public class BookingModel : PageModel
    {
        private readonly IPandaRepository pandaRepo;

        public BookingModel(IPandaRepository pandaRepository)
        {
            pandaRepo = pandaRepository;
        }

        public List<BookingOrder> OrdersUnbooked { get; set; }
        public List<MarketProduct> Market { get; set; }


        [BindProperty]
        public bool BuySellBool { get; set; }

        [BindProperty]
        public string ProductString { get; set; }

        [BindProperty]
        public string AmountString { get; set; }

        [BindProperty]
        public string ThresholdString { get; set; }

        public void OnGet()
        {
            Market = pandaRepo.GetAllMarketProducts()
                .OrderBy(mp => mp.ProductCode)
                .ToList();

            OrdersUnbooked = pandaRepo.GetBookingOrdersUnbooked()
                .OrderBy(o => o.ProductCode)
                .ToList();
        }

        public void OnPost()
        {
            BuySell BuySell;
            if      (BuySellBool)  BuySell = Enums.BuySell.Buy;
            else if (!BuySellBool) BuySell = Enums.BuySell.Sell;

            Int32.TryParse(AmountString, out int amount);
            Decimal.TryParse(ThresholdString.Replace(".", ","), out decimal threshold);

            Trader trader = pandaRepo.GetTraderByName(UserHelpers.GetUsername(User));
            MarketProduct marketProduct = pandaRepo.GetMarketProduct(ProductString);

            pandaRepo.PlaceBookingOrder(new BookingOrder(trader, marketProduct, amount, threshold));
            OnGet();
        }
    }
}