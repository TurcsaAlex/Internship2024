using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TorqueAndTread.Server.Migrations
{
    /// <inheritdoc />
    public partial class RoleSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Active", "CreatedById", "CreatedOn", "LastUpdatedById", "LastUpdatedOn", "Name" },
                values: new object[,]
                {
                    { -3, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "Supervisor" },
                    { -2, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "Operator" },
                    { -1, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "Administrator" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: -1);
        }
    }
}
