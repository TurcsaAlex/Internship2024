using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorqueAndTread.Server.Migrations
{
    /// <inheritdoc />
    public partial class BOMupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialIdBOMCode",
                table: "BOMs");

            migrationBuilder.AddColumn<string>(
                name: "BOMCode",
                table: "BOMs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "BOMs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BOMs_MaterialId",
                table: "BOMs",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_BOMs_Products_MaterialId",
                table: "BOMs",
                column: "MaterialId",
                principalTable: "Products",
                principalColumn: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOMs_Products_MaterialId",
                table: "BOMs");

            migrationBuilder.DropIndex(
                name: "IX_BOMs_MaterialId",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "BOMCode",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "BOMs");

            migrationBuilder.AddColumn<int>(
                name: "MaterialIdBOMCode",
                table: "BOMs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
