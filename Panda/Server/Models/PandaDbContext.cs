using Microsoft.EntityFrameworkCore;

namespace Server.Models
{
    public class PandaDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Trader> Traders { get; set; }
        public DbSet<MarketProduct> Market { get; set; }

        public PandaDbContext(DbContextOptions<PandaDbContext> options) : base(options)
        {
        }
    }
}