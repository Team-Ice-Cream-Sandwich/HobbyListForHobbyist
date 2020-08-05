using Microsoft.EntityFrameworkCore.Migrations;

namespace HobbyListForHobbyist.Migrations
{
    public partial class switchtoemail2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "MiniWishLists",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "MiniWishLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: "20.00");

            migrationBuilder.UpdateData(
                table: "MiniWishLists",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: "35.00");

            migrationBuilder.UpdateData(
                table: "MiniWishLists",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: "10");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "MiniWishLists",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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
    }
}
