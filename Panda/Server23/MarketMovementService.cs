using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Server23.Data;
using Server23.Entities;

namespace Server23
{
    internal class MarketMovementService : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;
        private List<MarketProduct> marketProducts;
        private List<BookingOrder> openBookingOrders;
        private IServiceScopeFactory ServiceScopeFactory;
        private IPandaRepository pandaRepo;

        /// <summary>
        /// the time that has passed since server start
        /// </summary>
        public ulong TicksPassed { get; private set; }

        /// <summary>
        /// the state of TicksPassed when the last update of marketPorduct Amounts happened
        /// </summary>
        public ulong LastUpdate { get; private set; }


        public MarketMovementService(ILogger<MarketMovementService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            ServiceScopeFactory = serviceScopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("MarketMovementService is starting.");
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(30));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _logger.LogInformation("MarketMovementService moving the market now...");
            TicksPassed++;
            GetMarketProductsFromDb();
            foreach (var mp in marketProducts)
            {
                using (var scope = ServiceScopeFactory.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    pandaRepo = services.GetRequiredService<IPandaRepository>();

                    int addedAmount = 25;
                    _logger.LogInformation($"Add {addedAmount} pieces of {mp.ProductCode}...");
                    pandaRepo.IncreaseMarketProductAmount(mp.ProductCode, addedAmount);

                    decimal newPrice = CalcNewPrice(mp, addedAmount);
                    _logger.LogInformation($"Set price of {mp.ProductCode} to {newPrice}...");
                    pandaRepo.SetMarketProductPrice(mp.ProductCode, newPrice);

                    BookAllOpenBookingOrders();
                }
            }
            _logger.LogInformation("MarketMovementService done moving the market.");
        }

        private decimal CalcNewPrice(MarketProduct marketProduct, int addedAmount)
        {
            int newAmount = marketProduct.AmountAvailable + addedAmount;
            if (newAmount == 0) return decimal.MaxValue;
            if (newAmount > 100000000) return 0.01m;
            return Convert.ToDecimal((1 / Math.Pow(newAmount, 1.01)) * 1000000);
        }

        private void BookAllOpenBookingOrders()
        {
            using (var scope = ServiceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;
                pandaRepo = services.GetRequiredService<IPandaRepository>();
                openBookingOrders = pandaRepo.GetBookingOrdersUnbooked().ToList();
                foreach( var bookingOrder in openBookingOrders)
                {
                    try
                    {
                        _logger.LogInformation($"Booking BookingOrder {bookingOrder.Id}: {bookingOrder.Amount} {bookingOrder.ProductCode} by {bookingOrder.Trader.Name}");
                        pandaRepo.BookBookingOrder(bookingOrder);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogInformation("Booking failed!!");
                    }

                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("MarketMovementService is stopping.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        private void GetMarketProductsFromDb()
        {
            using (var scope = ServiceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;
                pandaRepo = services.GetRequiredService<IPandaRepository>();
                marketProducts = pandaRepo.GetAllMarketProducts().ToList();
            }
        }

    }
}
