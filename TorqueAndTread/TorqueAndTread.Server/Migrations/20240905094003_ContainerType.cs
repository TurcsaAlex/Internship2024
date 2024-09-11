using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorqueAndTread.Server.Migrations
{
    /// <inheritdoc />
    public partial class ContainerType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContainerCode",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ContainerTypeId",
                table: "Containers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ContainerTypes",
                columns: table => new
                {
                    ContainerTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContainerTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedById = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerTypes", x => x.ContainerTypeId);
                    table.ForeignKey(
                        name: "FK_ContainerTypes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_ContainerTypes_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Containers_ContainerTypeId",
                table: "Containers",
                column: "ContainerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerTypes_CreatedById",
                table: "ContainerTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerTypes_LastUpdatedById",
                table: "ContainerTypes",
                column: "LastUpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_ContainerTypes_ContainerTypeId",
                table: "Containers",
                column: "ContainerTypeId",
                principalTable: "ContainerTypes",
                principalColumn: "ContainerTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Containers_ContainerTypes_ContainerTypeId",
                table: "Containers");

            migrationBuilder.DropTable(
                name: "ContainerTypes");

            migrationBuilder.DropIndex(
                name: "IX_Containers_ContainerTypeId",
                table: "Containers");

            migrationBuilder.DropColumn(
                name: "ContainerCode",
                table: "Containers");

            migrationBuilder.DropColumn(
                name: "ContainerTypeId",
                table: "Containers");
        }
    }
}
