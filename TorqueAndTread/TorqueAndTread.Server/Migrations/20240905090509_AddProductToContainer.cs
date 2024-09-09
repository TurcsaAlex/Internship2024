using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorqueAndTread.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddProductToContainer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Containers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Containers_ProductId",
                table: "Containers",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Products_ProductId",
                table: "Containers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Products_ProductId",
                table: "Containers");

            migrationBuilder.DropIndex(
                name: "IX_Containers_ProductId",
                table: "Containers");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Containers");
        }
    }
}
