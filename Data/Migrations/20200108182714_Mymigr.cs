using Microsoft.EntityFrameworkCore.Migrations;

namespace TobaccoStore.Migrations
{
    public partial class Mymigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tobacco_TobaccoId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TobaccoId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "TobaccoId",
                table: "Tobacco",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tobacco_TobaccoId",
                table: "Tobacco",
                column: "TobaccoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tobacco_Orders_TobaccoId",
                table: "Tobacco",
                column: "TobaccoId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tobacco_Orders_TobaccoId",
                table: "Tobacco");

            migrationBuilder.DropIndex(
                name: "IX_Tobacco_TobaccoId",
                table: "Tobacco");

            migrationBuilder.DropColumn(
                name: "TobaccoId",
                table: "Tobacco");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TobaccoId",
                table: "Orders",
                column: "TobaccoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tobacco_TobaccoId",
                table: "Orders",
                column: "TobaccoId",
                principalTable: "Tobacco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
