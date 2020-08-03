using Microsoft.EntityFrameworkCore.Migrations;

namespace HobbyListForHobbyist.Migrations
{
    public partial class fixedtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MinisToSupply_Supply_SupplyId",
                table: "MinisToSupply");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supply",
                table: "Supply");

            migrationBuilder.RenameTable(
                name: "Supply",
                newName: "Supplies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplies",
                table: "Supplies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MinisToSupply_Supplies_SupplyId",
                table: "MinisToSupply",
                column: "SupplyId",
                principalTable: "Supplies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MinisToSupply_Supplies_SupplyId",
                table: "MinisToSupply");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplies",
                table: "Supplies");

            migrationBuilder.RenameTable(
                name: "Supplies",
                newName: "Supply");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supply",
                table: "Supply",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MinisToSupply_Supply_SupplyId",
                table: "MinisToSupply",
                column: "SupplyId",
                principalTable: "Supply",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
