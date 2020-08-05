using Microsoft.EntityFrameworkCore.Migrations;

namespace HobbyListForHobbyist.Migrations
{
    public partial class switchtoemail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Supplies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Paints");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MiniWishLists");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MiniModels");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Supplies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Paints",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "MiniWishLists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "MiniModels",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MiniModels",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "admin@gmail.com");

            migrationBuilder.UpdateData(
                table: "MiniModels",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "admin@gmail.com");

            migrationBuilder.UpdateData(
                table: "MiniModels",
                keyColumn: "Id",
                keyValue: 3,
                column: "Email",
                value: "admin@gmail.com");

            migrationBuilder.UpdateData(
                table: "MiniWishLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "admin@gmail.com");

            migrationBuilder.UpdateData(
                table: "MiniWishLists",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "admin@gmail.com");

            migrationBuilder.UpdateData(
                table: "MiniWishLists",
                keyColumn: "Id",
                keyValue: 3,
                column: "Email",
                value: "admin@gmail.com");

            migrationBuilder.UpdateData(
                table: "Paints",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "admin@gmail.com");

            migrationBuilder.UpdateData(
                table: "Paints",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "admin@gmail.com");

            migrationBuilder.UpdateData(
                table: "Paints",
                keyColumn: "Id",
                keyValue: 3,
                column: "Email",
                value: "admin@gmail.com");

            migrationBuilder.UpdateData(
                table: "Supplies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "admin@gmail.com");

            migrationBuilder.UpdateData(
                table: "Supplies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "admin@gmail.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Supplies");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Paints");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "MiniWishLists");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "MiniModels");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Supplies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Paints",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MiniWishLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MiniModels",
                type: "nvarchar(max)",
                nullable: true);

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
                table: "MiniWishLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "f8166767-8e3a-4fbc-a179-a3dab9540c10");

            migrationBuilder.UpdateData(
                table: "MiniWishLists",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "f8166767-8e3a-4fbc-a179-a3dab9540c10");

            migrationBuilder.UpdateData(
                table: "MiniWishLists",
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
    }
}
