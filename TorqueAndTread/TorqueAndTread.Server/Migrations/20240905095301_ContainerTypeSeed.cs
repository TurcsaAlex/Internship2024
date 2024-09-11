using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TorqueAndTread.Server.Migrations
{
    /// <inheritdoc />
    public partial class ContainerTypeSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ContainerTypes",
                columns: new[] { "ContainerTypeId", "Active", "ContainerTypeName", "CreatedById", "CreatedOn", "LastUpdatedById", "LastUpdatedOn" },
                values: new object[,]
                {
                    { -2, true, "Box", -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -1, true, "Box", -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContainerTypes",
                keyColumn: "ContainerTypeId",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "ContainerTypes",
                keyColumn: "ContainerTypeId",
                keyValue: -1);
        }
    }
}
