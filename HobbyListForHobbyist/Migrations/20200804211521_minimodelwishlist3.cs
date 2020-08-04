using Microsoft.EntityFrameworkCore.Migrations;

namespace HobbyListForHobbyist.Migrations
{
    public partial class minimodelwishlist3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MinisToPaint_MiniWishLists_MiniWishListId",
                table: "MinisToPaint");

            migrationBuilder.DropForeignKey(
                name: "FK_MinisToSupply_MiniWishLists_MiniWishListId",
                table: "MinisToSupply");

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

            migrationBuilder.AddColumn<int>(
                name: "MiniModelId",
                table: "MiniWishLists",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MiniWishLists_MiniModelId",
                table: "MiniWishLists",
                column: "MiniModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_MiniWishLists_MiniModels_MiniModelId",
                table: "MiniWishLists",
                column: "MiniModelId",
                principalTable: "MiniModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MiniWishLists_MiniModels_MiniModelId",
                table: "MiniWishLists");

            migrationBuilder.DropIndex(
                name: "IX_MiniWishLists_MiniModelId",
                table: "MiniWishLists");

            migrationBuilder.DropColumn(
                name: "MiniModelId",
                table: "MiniWishLists");

            migrationBuilder.AddColumn<int>(
                name: "MiniWishListId",
                table: "MinisToSupply",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MiniWishListId",
                table: "MinisToPaint",
                type: "int",
                nullable: true);

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
    }
}
