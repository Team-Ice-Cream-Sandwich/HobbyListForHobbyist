using Microsoft.EntityFrameworkCore.Migrations;

namespace HobbyListForHobbyist.Migrations
{
    public partial class minimodelwishlist2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "MiniWishLists",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "MiniWishLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 20.00m);

            migrationBuilder.UpdateData(
                table: "MiniWishLists",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 35.00m);

            migrationBuilder.UpdateData(
                table: "MiniWishLists",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 10m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "MiniWishLists");
        }
    }
}
