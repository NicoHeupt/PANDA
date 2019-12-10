using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server23.Entities;

namespace Server23.Data
{
    public class PandaDbContext : IdentityDbContext<ApplicationUser>
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DepotPosition>()
                .HasKey(dp => new { dp.ProductCode, dp.DepotId });

            modelBuilder.Entity<Trader>()
                .HasAlternateKey(t => t.Name);

            modelBuilder.Entity<Trader>()
                .HasOne(t => t.BankAccount).WithOne();

            modelBuilder.Entity<Trader>()
                .OwnsOne(t => t.Depot);

            modelBuilder.Entity<BankAccount>()
                .HasMany(ba => ba.BankTransactions).WithOne();

            //modelBuilder.Entity<BankAccount>()
            //    .HasOne(ba => ba.Trader).WithOne();

            modelBuilder.Entity<BankTransaction>()
                .HasOne(bt => bt.BankAccount).WithMany();

            modelBuilder.Entity<Depot>()
                .HasMany(ba => ba.Transactions).WithOne();

            //modelBuilder.Entity<Depot>()
            //    .HasOne(d => d.Trader).WithOne();

            //modelBuilder.Entity<ApplicationUser>()
            //    .HasOne(t => t.Trader).WithOne();

            modelBuilder.Entity<BookingOrder>()
                .HasOne(t => t.Trader).WithMany();
        }
    }
}

