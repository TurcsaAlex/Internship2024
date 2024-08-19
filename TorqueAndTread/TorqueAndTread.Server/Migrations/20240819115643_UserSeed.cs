using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorqueAndTread.Server.Migrations
{
    /// <inheritdoc />
    public partial class UserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Active", "CreatedById", "CreatedOn", "Email", "LastUpdatedById", "LastUpdatedOn", "Name", "Password", "UserName" },
                values: new object[] { 1, true, 1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), "admin@admin.com", 1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", "", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
