using Microsoft.EntityFrameworkCore;

namespace Server.Entities
{
    public class PandaDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Trader> Traders { get; set; }
        public DbSet<MarketProduct> Market { get; set; }
        public DbSet<BookingOrder> BookingOrders { get; set; }

        public PandaDbContext(DbContextOptions<PandaDbContext> options) : base(options)
        {
        }
    }
}