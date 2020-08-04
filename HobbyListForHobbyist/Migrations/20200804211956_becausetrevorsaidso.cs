using Microsoft.EntityFrameworkCore.Migrations;

namespace HobbyListForHobbyist.Migrations
{
    public partial class becausetrevorsaidso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Paints",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "MiniModels",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "f8166767-8e3a-4fbc-a179-a3dab9540c10");

            migrationBuilder.UpdateData(
                table: "MiniModels",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "f8166767-8e3a-4fbc-a179-a3dab9540c10");

            migrationBuilder.UpdateData(
                table: "MiniModels",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "f8166767-8e3a-4fbc-a179-a3dab9540c10");

            migrationBuilder.UpdateData(
                table: "Paints",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "f8166767-8e3a-4fbc-a179-a3dab9540c10");

            migrationBuilder.UpdateData(
                table: "Paints",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "f8166767-8e3a-4fbc-a179-a3dab9540c10");

            migrationBuilder.UpdateData(
                table: "Paints",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "f8166767-8e3a-4fbc-a179-a3dab9540c10");

            migrationBuilder.UpdateData(
                table: "Supplies",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "f8166767-8e3a-4fbc-a179-a3dab9540c10");

            migrationBuilder.UpdateData(
                table: "Supplies",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "f8166767-8e3a-4fbc-a179-a3dab9540c10");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Paints",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "MiniModels",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MiniModels",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MiniModels",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Paints",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Paints",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Paints",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Supplies",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Supplies",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: null);
        }
    }
}
