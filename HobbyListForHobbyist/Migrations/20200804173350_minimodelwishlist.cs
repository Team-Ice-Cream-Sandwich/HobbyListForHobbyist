using Microsoft.EntityFrameworkCore.Migrations;

namespace HobbyListForHobbyist.Migrations
{
    public partial class minimodelwishlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Paints",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MiniWishListId",
                table: "MinisToSupply",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MiniWishListId",
                table: "MinisToPaint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MiniWishLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    PartNumber = table.Column<string>(nullable: true),
                    Faction = table.Column<string>(nullable: true),
                    PointCost = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiniWishLists", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "MiniWishLists",
                columns: new[] { "Id", "Faction", "Manufacturer", "Name", "PartNumber", "PointCost", "UserId" },
                values: new object[,]
                {
                    { 1, "East Army", "Forge Fire", "Chariot Personnel Carrier", "200", 250, "f8166767-8e3a-4fbc-a179-a3dab9540c10" },
                    { 2, "West Army", "Forge Fire", "Heavy support Squad", "300", 250, "f8166767-8e3a-4fbc-a179-a3dab9540c10" },
                    { 3, "North Army", "Forge Fire", "Chariot Armed Personnel Carrier", "30", 250, "f8166767-8e3a-4fbc-a179-a3dab9540c10" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_MinisToSupply_MiniWishListId",
                table: "MinisToSupply",
                column: "MiniWishListId");

            migrationBuilder.CreateIndex(
                name: "IX_MinisToPaint_MiniWishListId",
                table: "MinisToPaint",
                column: "MiniWishListId");

            migrationBuilder.AddForeignKey(
                name: "FK_MinisToPaint_MiniWishLists_MiniWishListId",
                table: "MinisToPaint",
                column: "MiniWishListId",
                principalTable: "MiniWishLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MinisToSupply_MiniWishLists_MiniWishListId",
                table: "MinisToSupply",
                column: "MiniWishListId",
                principalTable: "MiniWishLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MinisToPaint_MiniWishLists_MiniWishListId",
                table: "MinisToPaint");

            migrationBuilder.DropForeignKey(
                name: "FK_MinisToSupply_MiniWishLists_MiniWishListId",
                table: "MinisToSupply");

            migrationBuilder.DropTable(
                name: "MiniWishLists");

            migrationBuilder.DropIndex(
                name: "IX_MinisToSupply_MiniWishListId",
                table: "MinisToSupply");

            migrationBuilder.DropIndex(
                name: "IX_MinisToPaint_MiniWishListId",
                table: "MinisToPaint");

            migrationBuilder.DropColumn(
                name: "MiniWishListId",
                table: "MinisToSupply");

            migrationBuilder.DropColumn(
                name: "MiniWishListId",
                table: "MinisToPaint");

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
