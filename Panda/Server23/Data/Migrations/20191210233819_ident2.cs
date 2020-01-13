using Microsoft.EntityFrameworkCore.Migrations;

namespace Server23.Data.Migrations
{
    public partial class ident2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Traders_TraderId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TraderId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "TraderId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TraderId",
                table: "AspNetUsers",
                column: "TraderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Traders_TraderId",
                table: "AspNetUsers",
                column: "TraderId",
                principalTable: "Traders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Traders_TraderId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TraderId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "TraderId",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TraderId",
                table: "AspNetUsers",
                column: "TraderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Traders_TraderId",
                table: "AspNetUsers",
                column: "TraderId",
                principalTable: "Traders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
