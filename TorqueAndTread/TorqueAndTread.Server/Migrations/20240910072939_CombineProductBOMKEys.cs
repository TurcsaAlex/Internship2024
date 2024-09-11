using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorqueAndTread.Server.Migrations
{
    /// <inheritdoc />
    public partial class CombineProductBOMKEys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductBOMs",
                table: "ProductBOMs");

            migrationBuilder.DropIndex(
                name: "IX_ProductBOMs_ProductId",
                table: "ProductBOMs");

            migrationBuilder.DropColumn(
                name: "ProductBOMId",
                table: "ProductBOMs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductBOMs",
                table: "ProductBOMs",
                columns: new[] { "ProductId", "BOMId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductBOMs",
                table: "ProductBOMs");

            migrationBuilder.AddColumn<int>(
                name: "ProductBOMId",
                table: "ProductBOMs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductBOMs",
                table: "ProductBOMs",
                column: "ProductBOMId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBOMs_ProductId",
                table: "ProductBOMs",
                column: "ProductId");
        }
    }
}
