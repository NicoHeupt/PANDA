using Microsoft.EntityFrameworkCore.Migrations;

namespace Server23.Data.Migrations
{
    public partial class ident1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TraderId1",
                table: "BookingOrders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingOrders_TraderId1",
                table: "BookingOrders",
                column: "TraderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingOrders_Traders_TraderId1",
                table: "BookingOrders",
                column: "TraderId1",
                principalTable: "Traders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingOrders_Traders_TraderId1",
                table: "BookingOrders");

            migrationBuilder.DropIndex(
                name: "IX_BookingOrders_TraderId1",
                table: "BookingOrders");

            migrationBuilder.DropColumn(
                name: "TraderId1",
                table: "BookingOrders");
        }
    }
}
