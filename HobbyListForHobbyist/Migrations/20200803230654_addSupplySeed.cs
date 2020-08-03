using Microsoft.EntityFrameworkCore.Migrations;

namespace HobbyListForHobbyist.Migrations
{
    public partial class addSupplySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Supplies",
                columns: new[] { "Id", "Category", "Name", "UserId" },
                values: new object[] { 1, "Cutting", "Snipps", null });

            migrationBuilder.InsertData(
                table: "Supplies",
                columns: new[] { "Id", "Category", "Name", "UserId" },
                values: new object[] { 2, "Glue", "Plastiweld", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Supplies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Supplies",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
