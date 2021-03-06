﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Entities;

namespace Server.Migrations
{
    [DbContext(typeof(PandaDbContext))]
    [Migration("20191210103358_TakeOver")]
    partial class TakeOver
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Server.Entities.BankAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance");

                    b.HasKey("Id");

                    b.ToTable("BankAccount");
                });

            modelBuilder.Entity("Server.Entities.BankTransaction", b =>
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

            modelBuilder.Entity("Server.Entities.BookingOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<bool>("Booked");

                    b.Property<string>("ProductCode");

                    b.Property<decimal>("Threshold");

                    b.Property<int>("TraderId");

                    b.HasKey("Id");

                    b.HasIndex("ProductCode");

                    b.HasIndex("TraderId");

                    b.ToTable("BookingOrders");
                });

            modelBuilder.Entity("Server.Entities.Depot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Depot");
                });

            modelBuilder.Entity("Server.Entities.DepotPosition", b =>
                {
                    b.Property<string>("ProductCode");

                    b.Property<int>("DepotId");

                    b.Property<int>("Amount");

                    b.HasKey("ProductCode", "DepotId");

                    b.HasIndex("DepotId");

                    b.ToTable("DepotPosition");
                });

            modelBuilder.Entity("Server.Entities.DepotTransaction", b =>
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

            modelBuilder.Entity("Server.Entities.MarketProduct", b =>
                {
                    b.Property<string>("ProductCode");

                    b.Property<int>("AmountAvailable");

                    b.Property<decimal>("Price");

                    b.HasKey("ProductCode");

                    b.ToTable("Market");
                });

            modelBuilder.Entity("Server.Entities.Product", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AmountOverall");

                    b.HasKey("Code");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Server.Entities.Trader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BankAccountId");

                    b.Property<int?>("DepotId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("BankAccountId");

                    b.HasIndex("DepotId");

                    b.ToTable("Traders");
                });

            modelBuilder.Entity("Server.Entities.BankTransaction", b =>
                {
                    b.HasOne("Server.Entities.BankAccount")
                        .WithMany("BankTransactions")
                        .HasForeignKey("BankAccountId");

                    b.HasOne("Server.Entities.BankAccount", "BankAccount")
                        .WithMany()
                        .HasForeignKey("BankAccountId1");
                });

            modelBuilder.Entity("Server.Entities.BookingOrder", b =>
                {
                    b.HasOne("Server.Entities.MarketProduct", "MarketProduct")
                        .WithMany()
                        .HasForeignKey("ProductCode");

                    b.HasOne("Server.Entities.Trader", "Trader")
                        .WithMany("BookingOrders")
                        .HasForeignKey("TraderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Server.Entities.DepotPosition", b =>
                {
                    b.HasOne("Server.Entities.Depot", "Depot")
                        .WithMany("Positions")
                        .HasForeignKey("DepotId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Server.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductCode")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Server.Entities.DepotTransaction", b =>
                {
                    b.HasOne("Server.Entities.Depot", "Depot")
                        .WithMany()
                        .HasForeignKey("DepotId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Server.Entities.Depot")
                        .WithMany("Transactions")
                        .HasForeignKey("DepotId1");

                    b.HasOne("Server.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductCode");
                });

            modelBuilder.Entity("Server.Entities.MarketProduct", b =>
                {
                    b.HasOne("Server.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductCode")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Server.Entities.Trader", b =>
                {
                    b.HasOne("Server.Entities.BankAccount", "BankAccount")
                        .WithMany()
                        .HasForeignKey("BankAccountId");

                    b.HasOne("Server.Entities.Depot", "Depot")
                        .WithMany()
                        .HasForeignKey("DepotId");
                });
#pragma warning restore 612, 618
        }
    }
}
