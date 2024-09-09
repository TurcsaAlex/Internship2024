using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorqueAndTread.Server.Migrations
{
    /// <inheritdoc />
    public partial class ContainerTypeSeed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContainerTypes",
                keyColumn: "ContainerTypeId",
                keyValue: -2,
                column: "ContainerTypeName",
                value: "Palet");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContainerTypes",
                keyColumn: "ContainerTypeId",
                keyValue: -2,
                column: "ContainerTypeName",
                value: "Box");
        }
    }
}
