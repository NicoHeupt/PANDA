using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Server.Entities
{
    public class PandaDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Trader> Traders { get; set; }
        public DbSet<MarketProduct> Market { get; set; }
        public DbSet<BookingOrder> BookingOrders { get; set; }

        public PandaDbContext(DbContextOptions<PandaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DepotPosition>()
                .HasKey(dp => new { dp.ProductCode, dp.DepotId });

            modelBuilder.Entity<Trader>()
                .HasAlternateKey(t => t.Name);

            modelBuilder.Entity<Trader>()
                .OwnsOne(t => t.BankAccount);

            modelBuilder.Entity<Trader>()
                .OwnsOne(t => t.Depot);

            modelBuilder.Entity<BankAccount>()
                .HasMany(ba => ba.BankTransactions).WithOne();

            modelBuilder.Entity<Depot>()
                .HasMany(ba => ba.Transactions).WithOne();
        }
    }
}