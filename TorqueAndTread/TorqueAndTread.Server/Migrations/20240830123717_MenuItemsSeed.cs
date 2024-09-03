using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TorqueAndTread.Server.Migrations
{
    /// <inheritdoc />
    public partial class MenuItemsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "Active", "CreatedById", "CreatedOn", "IconClass", "LastUpdatedById", "LastUpdatedOn", "Link", "Name", "OrderNo" },
                values: new object[,]
                {
                    { -3, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), "", -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "", "am creat acest meniu", 1 },
                    { -2, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), "", -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "", "mergemenuitems", 1 },
                    { -1, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), "", -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "", "aleluia", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: -1);
        }
    }
}
