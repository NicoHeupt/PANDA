using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server31.Entities;

namespace Server31.Data
{
    public class PandaDbContext : IdentityDbContext
    {
        public PandaDbContext(DbContextOptions<PandaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Trader> Traders { get; set; }
        public DbSet<MarketProduct> Market { get; set; }
        public DbSet<BookingOrder> BookingOrders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trader>()
                .HasAlternateKey(t => t.Name);

            modelBuilder.Entity<Trader>()
                .OwnsOne(t => t.BankAccount)
                .WithOwner(ba => ba.Trader);

            modelBuilder.Entity<Trader>()
                .OwnsOne(t => t.Depot)
                .WithOwner(d => d.Trader);

            modelBuilder.Entity<BankAccount>()
                .OwnsMany(ba => ba.BankTransactions)
                .WithOwner(bt => bt.BankAccount);

            modelBuilder.Entity<Depot>()
                .OwnsMany(d => d.Transactions)
                .WithOwner(t => t.Depot);

            modelBuilder.Entity<Depot>()
                .OwnsMany(d => d.Positions)
                .WithOwner(p => p.Depot);

            modelBuilder.Entity<DepotPosition>()
                .HasOne(dp => dp.Product)
                .WithMany()
                .HasForeignKey(dp => dp.ProductCode);

            modelBuilder.Entity<DepotPosition>()
                .HasOne(dp => dp.Depot)
                .WithOne();
        }
    }
}
