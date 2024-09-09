using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorqueAndTread.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixUOM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Containers_UOMId",
                table: "Containers");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_UOMId",
                table: "Containers",
                column: "UOMId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Containers_UOMId",
                table: "Containers");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_UOMId",
                table: "Containers",
                column: "UOMId",
                unique: true);
        }
    }
}
