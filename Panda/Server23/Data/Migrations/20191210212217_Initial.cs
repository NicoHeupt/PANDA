using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server23.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TraderId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Depot",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    AmountOverall = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "BankTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BankAccountId1 = table.Column<int>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    BankAccountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankTransaction_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankTransaction_BankAccount_BankAccountId1",
                        column: x => x.BankAccountId1,
                        principalTable: "BankAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Traders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    BankAccountId = table.Column<int>(nullable: false),
                    DepotId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traders", x => x.Id);
                    table.UniqueConstraint("AK_Traders_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Traders_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Traders_Depot_DepotId",
                        column: x => x.DepotId,
                        principalTable: "Depot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepotPosition",
                columns: table => new
                {
                    DepotId = table.Column<int>(nullable: false),
                    ProductCode = table.Column<string>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepotPosition", x => new { x.ProductCode, x.DepotId });
                    table.ForeignKey(
                        name: "FK_DepotPosition_Depot_DepotId",
                        column: x => x.DepotId,
                        principalTable: "Depot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepotPosition_Products_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "Products",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepotTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepotId = table.Column<int>(nullable: false),
                    ProductCode = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    DepotId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepotTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepotTransaction_Depot_DepotId",
                        column: x => x.DepotId,
                        principalTable: "Depot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepotTransaction_Depot_DepotId1",
                        column: x => x.DepotId1,
                        principalTable: "Depot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepotTransaction_Products_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "Products",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Market",
                columns: table => new
                {
                    ProductCode = table.Column<string>(nullable: false),
                    AmountAvailable = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Market", x => x.ProductCode);
                    table.ForeignKey(
                        name: "FK_Market_Products_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "Products",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TraderId = table.Column<int>(nullable: false),
                    ProductCode = table.Column<string>(nullable: true),
                    Booked = table.Column<bool>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Threshold = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingOrders_Market_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "Market",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookingOrders_Traders_TraderId",
                        column: x => x.TraderId,
                        principalTable: "Traders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TraderId",
                table: "AspNetUsers",
                column: "TraderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankTransaction_BankAccountId",
                table: "BankTransaction",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransaction_BankAccountId1",
                table: "BankTransaction",
                column: "BankAccountId1");

            migrationBuilder.CreateIndex(
                name: "IX_BookingOrders_ProductCode",
                table: "BookingOrders",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_BookingOrders_TraderId",
                table: "BookingOrders",
                column: "TraderId");

            migrationBuilder.CreateIndex(
                name: "IX_DepotPosition_DepotId",
                table: "DepotPosition",
                column: "DepotId");

            migrationBuilder.CreateIndex(
                name: "IX_DepotTransaction_DepotId",
                table: "DepotTransaction",
                column: "DepotId");

            migrationBuilder.CreateIndex(
                name: "IX_DepotTransaction_DepotId1",
                table: "DepotTransaction",
                column: "DepotId1");

            migrationBuilder.CreateIndex(
                name: "IX_DepotTransaction_ProductCode",
                table: "DepotTransaction",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_Traders_BankAccountId",
                table: "Traders",
                column: "BankAccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Traders_DepotId",
                table: "Traders",
                column: "DepotId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Traders_TraderId",
                table: "AspNetUsers",
                column: "TraderId",
                principalTable: "Traders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Traders_TraderId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BankTransaction");

            migrationBuilder.DropTable(
                name: "BookingOrders");

            migrationBuilder.DropTable(
                name: "DepotPosition");

            migrationBuilder.DropTable(
                name: "DepotTransaction");

            migrationBuilder.DropTable(
                name: "Market");

            migrationBuilder.DropTable(
                name: "Traders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "Depot");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TraderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TraderId",
                table: "AspNetUsers");
        }
    }
}
