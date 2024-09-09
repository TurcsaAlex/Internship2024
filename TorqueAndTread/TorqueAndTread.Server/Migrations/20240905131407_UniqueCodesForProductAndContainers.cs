using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorqueAndTread.Server.Migrations
{
    /// <inheritdoc />
    public partial class UniqueCodesForProductAndContainers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductCodeName",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ContainerCode",
                table: "Containers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCodeName",
                table: "Products",
                column: "ProductCodeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Containers_ContainerCode",
                table: "Containers",
                column: "ContainerCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCodeName",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Containers_ContainerCode",
                table: "Containers");

            migrationBuilder.AlterColumn<string>(
                name: "ProductCodeName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ContainerCode",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
