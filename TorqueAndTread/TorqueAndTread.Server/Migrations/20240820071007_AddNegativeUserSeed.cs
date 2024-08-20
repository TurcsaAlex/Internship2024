using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TorqueAndTread.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddNegativeUserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Active", "CreatedById", "CreatedOn", "Email", "LastUpdatedById", "LastUpdatedOn", "Name", "Password", "UserName" },
                values: new object[,]
                {
                    { -1, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), "admin@admin.com", -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", "", "admin" },
                    { -3, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), "admin3@admin.com", -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", "", "admin2" },
                    { -2, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), "admin2@admin.com", -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", "", "admin1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -1);
        }
    }
}
