﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server23.Data;

namespace Server23.Data.Migrations
{
    [DbContext(typeof(PandaDbContext))]
    [Migration("20191210224728_ident1")]
    partial class ident1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Server23.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("TraderId");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("TraderId")
                        .IsUnique();

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Server23.Entities.BankAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance");

                    b.HasKey("Id");

                    b.ToTable("BankAccount");
                });

            modelBuilder.Entity("Server23.Entities.BankTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<int?>("BankAccountId");

                    b.Property<int?>("BankAccountId1");

                    b.Property<string>("Reason");

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId");

                    b.HasIndex("BankAccountId1");

                    b.ToTable("BankTransaction");
                });

            modelBuilder.Entity("Server23.Entities.BookingOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<bool>("Booked");

                    b.Property<string>("ProductCode");

                    b.Property<decimal>("Threshold");

                    b.Property<int>("TraderId");

                    b.Property<int?>("TraderId1");

                    b.HasKey("Id");

                    b.HasIndex("ProductCode");

                    b.HasIndex("TraderId");

                    b.HasIndex("TraderId1");

                    b.ToTable("BookingOrders");
                });

            modelBuilder.Entity("Server23.Entities.Depot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Depot");
                });

            modelBuilder.Entity("Server23.Entities.DepotPosition", b =>
                {
                    b.Property<string>("ProductCode");

                    b.Property<int>("DepotId");

                    b.Property<int>("Amount");

                    b.HasKey("ProductCode", "DepotId");

                    b.HasIndex("DepotId");

                    b.ToTable("DepotPosition");
                });

            modelBuilder.Entity("Server23.Entities.DepotTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int>("DepotId");

                    b.Property<int?>("DepotId1");

                    b.Property<decimal>("Price");

                    b.Property<string>("ProductCode");

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.HasIndex("DepotId");

                    b.HasIndex("DepotId1");

                    b.HasIndex("ProductCode");

                    b.ToTable("DepotTransaction");
                });

            modelBuilder.Entity("Server23.Entities.MarketProduct", b =>
                {
                    b.Property<string>("ProductCode");

                    b.Property<int>("AmountAvailable");

                    b.Property<decimal>("Price");

                    b.HasKey("ProductCode");

                    b.ToTable("Market");
                });

            modelBuilder.Entity("Server23.Entities.Product", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AmountOverall");

                    b.HasKey("Code");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Server23.Entities.Trader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BankAccountId");

                    b.Property<int?>("DepotId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("BankAccountId")
                        .IsUnique();

                    b.HasIndex("DepotId");

                    b.ToTable("Traders");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Server23.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Server23.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Server23.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Server23.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Server23.Entities.ApplicationUser", b =>
                {
                    b.HasOne("Server23.Entities.Trader", "Trader")
                        .WithOne()
                        .HasForeignKey("Server23.Entities.ApplicationUser", "TraderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Server23.Entities.BankTransaction", b =>
                {
                    b.HasOne("Server23.Entities.BankAccount")
                        .WithMany("BankTransactions")
                        .HasForeignKey("BankAccountId");

                    b.HasOne("Server23.Entities.BankAccount", "BankAccount")
                        .WithMany()
                        .HasForeignKey("BankAccountId1");
                });

            modelBuilder.Entity("Server23.Entities.BookingOrder", b =>
                {
                    b.HasOne("Server23.Entities.MarketProduct", "MarketProduct")
                        .WithMany()
                        .HasForeignKey("ProductCode");

                    b.HasOne("Server23.Entities.Trader", "Trader")
                        .WithMany()
                        .HasForeignKey("TraderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Server23.Entities.Trader")
                        .WithMany("BookingOrders")
                        .HasForeignKey("TraderId1");
                });

            modelBuilder.Entity("Server23.Entities.DepotPosition", b =>
                {
                    b.HasOne("Server23.Entities.Depot", "Depot")
                        .WithMany("Positions")
                        .HasForeignKey("DepotId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Server23.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductCode")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Server23.Entities.DepotTransaction", b =>
                {
                    b.HasOne("Server23.Entities.Depot", "Depot")
                        .WithMany()
                        .HasForeignKey("DepotId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Server23.Entities.Depot")
                        .WithMany("Transactions")
                        .HasForeignKey("DepotId1");

                    b.HasOne("Server23.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductCode");
                });

            modelBuilder.Entity("Server23.Entities.MarketProduct", b =>
                {
                    b.HasOne("Server23.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductCode")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Server23.Entities.Trader", b =>
                {
                    b.HasOne("Server23.Entities.BankAccount", "BankAccount")
                        .WithOne()
                        .HasForeignKey("Server23.Entities.Trader", "BankAccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Server23.Entities.Depot", "Depot")
                        .WithMany()
                        .HasForeignKey("DepotId");
                });
#pragma warning restore 612, 618
        }
    }
}
