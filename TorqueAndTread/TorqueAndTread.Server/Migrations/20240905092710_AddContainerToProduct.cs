using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorqueAndTread.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddContainerToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContainerId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ContainerId",
                table: "Products",
                column: "ContainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Containers_ContainerId",
                table: "Products",
                column: "ContainerId",
                principalTable: "Containers",
                principalColumn: "ContainerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Containers_ContainerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ContainerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ContainerId",
                table: "Products");
        }
    }
}
